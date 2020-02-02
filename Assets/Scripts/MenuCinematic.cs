using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utiles;

public class MenuCinematic : MonoBehaviour
{
    public Animator anim;
    public Camera cam;
    public SpriteRenderer background;
    public MoveToTarget mtt;
    public Animator relojanim;
    public Image relojsr;
    public Sprite doce;
    
    public AudioSource music;
    public AudioSource bostezo;
    public AudioSource pasos;
    public float fadeAudioStep = 0.1f;
    
    private void Start()
    {
        OrtoCamUtilities.MatchWidth(cam, background, true);
        OrtoCamUtilities.MatchTopEdge(cam, background);
        mtt.eventFinishedMoved += OnMoveFinished;
        MoveCameraToBottom();
        music.Play();
    }

    private void OnMoveFinished()
    {
        anim.SetTrigger("appear");
    }

    private void MoveCameraToBottom()
    {
        float semiHeight = background.bounds.extents.y;
        float backBottom = background.transform.position.y - semiHeight;

        var cameraPos = cam.transform.position;
        cameraPos.y = backBottom + cam.orthographicSize;
        mtt.target = cameraPos;
        mtt.Move();
    }

    public void BeginPlayCinematic()
    {
        anim.SetTrigger("disappear");
        
        Destroy(relojanim);
        relojsr.sprite = doce;

        StartCoroutine(fadeAudio(music));
    }

    public IEnumerator fadeAudio(AudioSource a)
    {
        while (music.volume > 0)
        {
            music.volume -= fadeAudioStep;
//            a.clip.
            yield return null;
        }

        music.volume = 0;
        music.Stop();
    }
}
