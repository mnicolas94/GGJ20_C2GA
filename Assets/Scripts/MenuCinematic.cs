﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utiles;

public class MenuCinematic : MonoBehaviour
{
    public Animator edificioanim;
    public Animator anim;
    public Camera cam;
    public SpriteRenderer background;
    public MoveToTarget mtt;
    public Animator relojanim;
    public Image relojsr;
    public Sprite doce;
    
    public AudioSource cuna;
    public float cunaFade;
    public AudioSource music;
    public float musicFade;
    public AudioSource bostezo;
    public float bostezoFade;
    public AudioSource pasos;
    
    private void Start()
    {
//        OrtoCamUtilities.MatchWidth(cam, background, true);
//        OrtoCamUtilities.MatchTopEdge(cam, background);
//        mtt.eventFinishedMoved += OnMoveFinished;
//        MoveCameraToBottom();
        OrtoCamUtilities.MatchSize(cam, background, true, true);
        
        cuna.Play();
        IEnumerator fadeSound1 = fadecuna();
        StartCoroutine (fadeSound1);
    }

    private void appear()
    {
        anim.SetTrigger("appear");
    }

    public void BeginPlayCinematic()
    {
        anim.SetTrigger("disappear");
        
        Destroy(relojanim);
        relojsr.sprite = doce;

        IEnumerator fadeSound1 = fademusic();
        StartCoroutine (fadeSound1);
    }

    public IEnumerator fadecuna()
    {
        while (cuna.volume > 0)
        {
            cuna.volume = cuna.volume - cunaFade;
            yield return null;
        }

        cuna.volume = 0;
        cuna.Stop();

        edificioanim.enabled = true;
        anim.SetTrigger("appear");
        music.Play();
        print("music");
    }
    
    public IEnumerator fademusic()
    {
        while (music.volume > 0)
        {
            music.volume = music.volume - musicFade;
            yield return null;
        }

        music.volume = 0;
        music.Stop();
        
        bostezo.Play();
        IEnumerator fadeSound1 = fadebostezo();
        StartCoroutine (fadeSound1);
    }
    
    public IEnumerator fadebostezo()
    {
        while (bostezo.volume > 0)
        {
            bostezo.volume = bostezo.volume - bostezoFade;
            yield return null;
        }

        pasos.Play();
        Invoke("cambiarescena", 18f);
    }

    void cambiarescena()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
