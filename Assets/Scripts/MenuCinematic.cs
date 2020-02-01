using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCinematic : MonoBehaviour
{
    public Animator anim;
    public Transform cam;
    public Vector3 backPos;

    public void BackgroundSetPos()
    {
        cam.position = backPos;
        print("fin");
    }
}
