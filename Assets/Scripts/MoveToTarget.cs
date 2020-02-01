using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform obj;
    public Vector3 target;
    public float moveSpeed;
    public float stopThreshold;
    
    public bool acceleratedMovement;
    
    public Action eventFinishedMoved;
    
    public IEnumerator Move(Vector3 pos)
    {
        Vector3 currentPos = obj.transform.position;
        while ((currentPos - pos).magnitude > stopThreshold)
        {
            currentPos = obj.transform.position;
            if (acceleratedMovement)
                obj.transform.position = Vector3.Lerp(currentPos, target, moveSpeed);
            else
                obj.transform.position = currentPos + ((target - currentPos).normalized * moveSpeed);
            
            yield return null;
        }

        obj.transform.position = target;
        eventFinishedMoved?.Invoke();
    }
    
    [NaughtyAttributes.Button()]
    public void Move()
    {
        StartCoroutine(Move(target));
    }

//    public Animator anim;
//    public void Anmov()
//    {
//        anim
//    }
}
