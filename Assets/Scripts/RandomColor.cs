using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RandomColor : MonoBehaviour
{
    //lista z kolorowymi spritami do losowania - dodaje je w inspektorze
    public Sprite[] spriteArray;
    //co ile maj� si� zmieniac kolory
    public float repeatTime = 1;

    // zmienna potrzeban do wy�wietlania losowych kolor�w
    private int randomNumber;
    // aby zmienia� sprity musimy dosta� si� do komponentu SpriteRenderer
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // pobieramy komponent SpriteRenderer
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //Invoke bedzie wykonywa� funkcj� ChangeSprite cyklicznie co okre�lony czas - repeatTime
        InvokeRepeating("ChangeSprite", 0, repeatTime);
    }

    void ChangeSprite()
    {
        //upewniamy si�, �e przyciski s� klikalne
        Collider2D myColliderr = GetComponent<BoxCollider2D>();
        myColliderr.enabled = true;

        //upewniamy sie �e sprity s� widoczne
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.color = Color.white;

        //losowa liczba z zakresu
        randomNumber = Random.Range(0, spriteArray.Length);
        //usatwaimy nowy sprite wg losowej liczby
        spriteRenderer.sprite = spriteArray[randomNumber];
    }

}

