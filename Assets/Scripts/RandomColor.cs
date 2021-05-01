using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RandomColor : MonoBehaviour
{
    //lista z kolorowymi spritami do losowania - dodaje je w inspektorze
    public Sprite[] spriteArray;
    //co ile maj¹ siê zmieniac kolory
    public float repeatTime = 1;

    // zmienna potrzeban do wyœwietlania losowych kolorów
    private int randomNumber;
    // aby zmieniaæ sprity musimy dostaæ siê do komponentu SpriteRenderer
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // pobieramy komponent SpriteRenderer
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //Invoke bedzie wykonywaæ funkcjê ChangeSprite cyklicznie co okreœlony czas - repeatTime
        InvokeRepeating("ChangeSprite", 0, repeatTime);
    }

    void ChangeSprite()
    {
        //upewniamy siê, ¿e przyciski s¹ klikalne
        Collider2D myColliderr = GetComponent<BoxCollider2D>();
        myColliderr.enabled = true;

        //upewniamy sie ¿e sprity s¹ widoczne
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.color = Color.white;

        //losowa liczba z zakresu
        randomNumber = Random.Range(0, spriteArray.Length);
        //usatwaimy nowy sprite wg losowej liczby
        spriteRenderer.sprite = spriteArray[randomNumber];
    }

}

