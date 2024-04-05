using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Button resetButton;
    public Button menuButton;
    public GameObject endScreens;
    private void Update()
    {
        if (playerScript.playerAlive && playerScript.gameActive == true)
        {
            resetButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
            endScreens.gameObject.SetActive(false);
        }
        else if (playerScript.playerAlive && playerScript.gameActive == false)
        {
            resetButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            endScreens.gameObject.SetActive(true);
        }
        else
        {
            resetButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
