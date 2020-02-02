using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Action eventGameEnded;
    public Action eventGameWinned;

    public GameObject menu;
    public GameObject winCartel;
    public GameObject loseCartel;

    public Transform whiteLight;
    public Transform colorLight;
    public Transform spotLight;

    private void Awake() {
       if(instance == null)
       {
           instance = this;
       }
       else
       {
           Destroy(this.gameObject);
       }
    }
    public void LoseGame()
    {
        eventGameEnded?.Invoke();
        print("Game losed");
        
        menu.SetActive(true);
        loseCartel.SetActive(true);
    }

     public void WinGame()
    {
        eventGameWinned?.Invoke();
        print("Game winned");
        
        menu.SetActive(true);
        // cartel win
        winCartel.SetActive(true);
    }
}
