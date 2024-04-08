using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject gameMenu;
    public Image thisEndCard;
    public GameObject endScreens;

   
    private void Update()
    {
        if (playerScript.playerAlive && playerScript.gameActive == true)
        {
            gameMenu.SetActive(false);
            endScreens.gameObject.SetActive(false);
            thisEndCard.gameObject.SetActive(false);
        }
        else if (playerScript.playerAlive && playerScript.gameActive == false)
        {
            gameMenu.SetActive(true);
            endScreens.gameObject.SetActive(true);
        }
        else
        {
            gameMenu.SetActive(true);
            thisEndCard.gameObject.SetActive(true);
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
