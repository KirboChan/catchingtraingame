using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    SpriteRenderer spriteRend;
    public static playerHealth instance;
    public static int health = 3;
    [SerializeField] int flashes;
    [SerializeField] float invincibilityFrames;
    public static bool isInvisible;
    public Image[] coffee;
    public Sprite fullCoffee;
    public Sprite emptyCoffee;



    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        isInvisible = false;
        instance = this;    
        health = 3;
    }
    private void Update()
    {
        foreach(Image img in coffee)
        {
            img.sprite = emptyCoffee;
        }
        for (int i = 0; i < health; i++)
        {
            coffee[i].sprite = fullCoffee;
        }
    }

    public IEnumerator InvincibilityFrames()
    {
        isInvisible = true;
        yield return new WaitForSeconds(invincibilityFrames);
        isInvisible = false;
    }
}
