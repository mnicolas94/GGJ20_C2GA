using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Action eventGameEnded;
    public Action eventGameWinned;
    
    public AudioSource music;
    public AudioSource boo;
    
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
        
        var f = fademusic();
        StartCoroutine(f);
        boo.Play();
        stopAllDancers();
    }

     public void WinGame()
    {
        eventGameWinned?.Invoke();
        print("Game winned");
        
        menu.SetActive(true);
        // cartel win
        winCartel.SetActive(true);
        GetComponent<AudioSource>().Play();

        var f = fademusic();
        StartCoroutine(f);
        stopAllDancers();
    }
     
     public IEnumerator fademusic()
     {
         while (music.volume > 0)
         {
             music.volume = music.volume - 0.01f;
             yield return null;
         }

         music.Play();
         Invoke("cambiarescena", 18f);
     }

     void stopAllDancers()
     {
         foreach (var m in FindObjectsOfType<Movement>())
         {
             m.Move(Vector2.zero);
             m.enabled = false;
         }
     }
}
