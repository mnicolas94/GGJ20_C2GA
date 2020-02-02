using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utiles;

public class MenuCinematic : MonoBehaviour
{
    public Animator anim;
    public Camera cam;
    public SpriteRenderer background;
    public MoveToTarget mtt;
    public AudioSource audio;
    
    private void Start()
    {
        OrtoCamUtilities.MatchWidth(cam, background, true);
        OrtoCamUtilities.MatchTopEdge(cam, background);
        mtt.eventFinishedMoved += OnMoveFinished;
        MoveCameraToBottom();
        audio.Play();
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
    }
}
