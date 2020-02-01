using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    public float minSpeedModiffier;
    public float maxSpeedModiffier;

    [SerializeField]  // lo serializo para que sea privado pero aún así pueda modificarlo en el editor
    private float _speed;
    private float _speedModiffier;
    
    public float Speed => _speed;

    [NaughtyAttributes.ShowNativeProperty]
    public float MinSpeedPosible => Speed * (minSpeedModiffier + 1);
    
    [NaughtyAttributes.ShowNativeProperty]
    public float MaxSpeedPosible => Speed * (maxSpeedModiffier + 1);
    
    [NaughtyAttributes.ShowNativeProperty]
    public float SpeedModifier
    {
        get => _speedModiffier;
        set => _speedModiffier = Math.Max(minSpeedModiffier, Math.Min(maxSpeedModiffier, value));
    }

    [NaughtyAttributes.ShowNativeProperty]
    public float SpeedModified => Speed * (SpeedModifier + 1);

    /// <summary>
    /// Velocidad relativa a la mínima y máxima velocidad permitida. Rango [0 ; 1]
    /// </summary>
    [NaughtyAttributes.ShowNativeProperty]
    public float RelativeModiffiedSpeed => (SpeedModified - MinSpeedPosible) / (MaxSpeedPosible - MinSpeedPosible);
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 dir)
    {
        if (!enabled)
            return;
        _rb.velocity = dir.normalized * SpeedModified;
    }
}
