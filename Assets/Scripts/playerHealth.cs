using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public static int health = 3;
    public Image[] coffee;
    public Sprite fullCoffee;
    public Sprite emptyCoffee;

    private void Start()
    {
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
}
