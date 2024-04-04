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

    private void Update()
    {
        if (playerScript.playerAlive)
        {
            resetButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
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
