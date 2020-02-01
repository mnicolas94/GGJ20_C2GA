using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public string playSceneName;
    
    public void ChangeToPlayScene()
    {
        SceneManager.LoadScene(playSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
