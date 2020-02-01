using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMovementController : MonoBehaviour
{
    public Movement movement;
    public Bounds areaToMove;

    public float restTime;
    public float variance;
    
    public float moveThreshold = 0.01f;
    
    private Vector2 _moveTo;
    private float _timeToWalk;

    private void Start()
    {
        _moveTo = areaToMove.RandomPos();
    }

    private void FixedUpdate()
    {
        if ((((Vector2) transform.position) - _moveTo).magnitude < moveThreshold)
        {
            _moveTo = areaToMove.RandomPos();

            _timeToWalk = Time.time + restTime;
            // TODO tiempo aleatorio
        }
        
        if (Time.time >= _timeToWalk)
            movement.Move(_moveTo - (Vector2)transform.position);
        else
            movement.Move(Vector2.zero); // para que se detenga
    }
}
