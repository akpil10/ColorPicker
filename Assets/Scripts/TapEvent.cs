using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEvent : MonoBehaviour
{
    //sprite pod kliknientym prrzyciskiem
    private Sprite mySprite;
    // lista obiektów do porównania z kliknietym spritem
    public GameObject[] targets; 


    // Update is called once per frame
    void Update()
    {
        // pobieramy wszystkie obiekty z Tagiem
        targets = GameObject.FindGameObjectsWithTag("Target");
    }

    // gdy klkniemy myszk¹ na obiekt
    private void OnMouseDown()
    {
        //zamieniamy kolor sprita na czarny
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.color = Color.black;

        //deaktywujemy collider - nie bedzie mo¿na nacisn¹c go 2 razy
        Collider2D myColliderr = GetComponent<BoxCollider2D>();
        myColliderr.enabled = false;

        //Pobieramy sprita
        mySprite = GetComponent<SpriteRenderer>().sprite;
        
        //Pobieramy sprita do porównania z 1 obiektu na liœcie
        Sprite targetSprite = targets[0].GetComponent<SpriteRenderer>().sprite;

        //Pobieramy component Controller - bêdziemy wysy³ac do niego informacje o punktach
        GameObject gameController = GameObject.Find("Controller");

        // Jeœli sprite obiektu kliknietego jest taki sam jak sprit pierwszego obiektu na lisæie targets
        if (targetSprite == mySprite)
        {
            //dodaj +10 do scora
            gameController.GetComponent<GameController>().myScore += 10;
            // dodaj +1 do zmiennej zliczaj¹cej iloœæ poprawyhc trafieñ
            gameController.GetComponent<GameController>().hitCounter += 1;

            //Po trafieniu obiekt jest deaktywowany
            targets[0].gameObject.SetActive(false);
        }
        else
        {
            //jeœli klikneliœmy z³y przycisk -10 do scora
            gameController.GetComponent<GameController>().myScore -= 10;
        }
            
    }
}
