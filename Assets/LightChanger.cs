using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LightChanger : MonoBehaviour
{
    public Light l;
    public float delay;
    private float _cooldown;
    private void Update()
    {
        if (Time.time > _cooldown)
        {
            ChangeColor();
            _cooldown = Time.time + delay;
        }
    }

    void ChangeColor()
    {
        l.color = UnityEngine.Random.ColorHSV();
    }
}
