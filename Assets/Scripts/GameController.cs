using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // text z UI do wy�wietlania scora
    public Text scoreText;
    //aktualny score
    public int myScore = 0;
    //liczba poprawnych trafie�
    public int hitCounter = 0;

    //slider do wy�witlania czasu
    public Slider timeSlider;
    //czas kt�ry pozosta�
    public float timeRemaining = 5;
    //zmienna do obliczania czasu
    private float timeToEnd = 0;

    //obiekty na dole ekranu (nasz cel)
    private GameObject[] targets;

    // Start is called before the first frame update
    void Start()
    {
        //pobieramy wszystkie obiekty z Tagiem
        targets = GameObject.FindGameObjectsWithTag("Target");
        //usatwiamy zmienn� 
        timeToEnd = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        //aktualizujem scora 
        scoreText.text = myScore.ToString();

        //sprawiamy �e czsa P�YNIE
        if (timeToEnd > 0)
        {
            timeToEnd -= Time.deltaTime;
            //usatwiamy warto�� slidera
            timeSlider.value = timeToEnd;

            //sprawdzamy czy trafili�my 5x
            if(hitCounter == 5)
            {
                //je��i tak to resetujemy czas
                timeToEnd = timeRemaining;
                // dodajemy do scora bonus
                myScore += 50;
                //i ponownie losujemy kolory w dolnym rz�dzie
                ColorRestart();
            }
        }
        // je�li czas si� sko�czy�
        else
        {
            //je��i tak to resetujemy czas
            timeToEnd = timeRemaining;
            // odejmujemy do scora bonus
            myScore -= 50;
            //i ponownie losujemy kolory w dolnym rz�dzie
            ColorRestart();
        }
         

    }

    // Losujemy kolory, aby lista by�a w odpowiedniej kolejno�ci najlepiej najpierw deaktywowac wszystkie obiekty 
    //a nastepnie wszystkie je aktywowa�.
    void ColorRestart()
    {
        foreach (GameObject item in targets)
        {
            item.SetActive(false);
            item.SetActive(true);
            //po losowaniu resetujemy liczb� trafie�
            hitCounter = 0;
        }
    }
}
