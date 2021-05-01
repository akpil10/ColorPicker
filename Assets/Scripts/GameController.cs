using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // text z UI do wyœwietlania scora
    public Text scoreText;
    //aktualny score
    public int myScore = 0;
    //liczba poprawnych trafieñ
    public int hitCounter = 0;

    //slider do wyœwitlania czasu
    public Slider timeSlider;
    //czas który pozosta³
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
        //usatwiamy zmienn¹ 
        timeToEnd = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        //aktualizujem scora 
        scoreText.text = myScore.ToString();

        //sprawiamy ¿e czsa P£YNIE
        if (timeToEnd > 0)
        {
            timeToEnd -= Time.deltaTime;
            //usatwiamy wartoœæ slidera
            timeSlider.value = timeToEnd;

            //sprawdzamy czy trafiliœmy 5x
            if(hitCounter == 5)
            {
                //jeœ³i tak to resetujemy czas
                timeToEnd = timeRemaining;
                // dodajemy do scora bonus
                myScore += 50;
                //i ponownie losujemy kolory w dolnym rzêdzie
                ColorRestart();
            }
        }
        // jeœli czas siê skoñczy³
        else
        {
            //jeœ³i tak to resetujemy czas
            timeToEnd = timeRemaining;
            // odejmujemy do scora bonus
            myScore -= 50;
            //i ponownie losujemy kolory w dolnym rzêdzie
            ColorRestart();
        }
         

    }

    // Losujemy kolory, aby lista by³a w odpowiedniej kolejnoœci najlepiej najpierw deaktywowac wszystkie obiekty 
    //a nastepnie wszystkie je aktywowaæ.
    void ColorRestart()
    {
        foreach (GameObject item in targets)
        {
            item.SetActive(false);
            item.SetActive(true);
            //po losowaniu resetujemy liczbê trafieñ
            hitCounter = 0;
        }
    }
}
