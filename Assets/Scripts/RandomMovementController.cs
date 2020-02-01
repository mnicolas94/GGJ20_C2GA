using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMovementController : MonoBehaviour
{
    public Movement movement;
    public Bounds areaToMove;
    public Bounds localAreaToMove;
    
    public float restTime;
    public float variance;
    
    public float moveThreshold = 0.01f;
    
    private Vector2 _moveTo;
    private float _timeToWalk;

    private void Start()
    {
        RandomTimeAndPos();
    }

    private void RandomTimeAndPos()
    {
        localAreaToMove.center = movement.transform.position;
        _moveTo = localAreaToMove.RandomPos();

        if (!areaToMove.Contains(_moveTo))
        {
            _moveTo = areaToMove.ClosestPoint(_moveTo);
        }
        
        float randrest = Random.Range(restTime - variance, restTime + variance); 
        _timeToWalk = Time.time + randrest;
    }
    
    private void FixedUpdate()
    {
        if ((((Vector2) transform.position) - _moveTo).magnitude < moveThreshold)
        {
            RandomTimeAndPos();
        }
        
        if (Time.time >= _timeToWalk)
            movement.Move(_moveTo - (Vector2)transform.position);
        else
            movement.Move(Vector2.zero); // para que se detenga
    }
}
