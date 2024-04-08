using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    public GameObject mainMenuSet;
    public GameObject creditsSet;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuSet.SetActive(true);
        creditsSet.SetActive(false);
    }

    // Update is called once per frame
    
    public void SetMainMenuActive()
    {
        mainMenuSet.SetActive(true);
        creditsSet.SetActive(false);
    }

    public void SetCreditsActive()
    {
        mainMenuSet.SetActive(false);
        creditsSet.SetActive(true);
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
