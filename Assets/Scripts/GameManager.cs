using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Action eventGameEnded;
    public Action eventGameWinned;
    
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
    }

     public void WinGame()
    {
        eventGameWinned?.Invoke();
    }
}
