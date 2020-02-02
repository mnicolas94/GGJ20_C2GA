using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject container;
    public string playSceneName;
    public string mainMenuSceneName;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == playSceneName && Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(!container.activeSelf);
        }
    }

    public void ChangeToPlayScene()
    {
        SceneManager.LoadScene(playSceneName);
    }
    
    public void ChangeToMainMenu(){
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
