// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDancer : MonoBehaviour
{
    public float probabilityToDance;
    public float timeToRespond;

    private bool onCollision;

    public KeyAnimationDict keyAnimationDict;
     
    private void OnTriggerEnter2D(Collider2D other)
    {
        // decidir aleatoriamente si bailar o no
        // decidir tipo de baile
        // detener al player
        // calcular el tiempo de que si el player no ha apretado la tecla
            // 
        onCollision = true;
        if(other.tag == "Player")
        {
            this.stopPlayer(other);
        }
    }

    private void Update() {
        float timeToDance = 0;
        if(onCollision)
        {
            timeToDance = Time.time + timeToRespond;
        }
        if(timeToDance <= Time.time)
        {
            GameManager.instance.LoseGame();
        }
    }

    private bool canDance()
    {
        bool canDance = false;
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            canDance = false;
        }
        else
        {
            canDance = true;
        }
        return canDance;
    }


    private KeyAnimationDict danceType()
    {
        var l = keyAnimationDict.keys;
        var randomKey = Random.Range(0, l.count());
        return keyAnimationDict[randomKey];
    }

    private void stopPlayer(Collider2D other)
    {
        other.GetComponent<Movement>().enabled = false;
    }
}

[System.Serializable()]
public class KeyAnimationDict: SerializableDictionaryBase<KeyCode, string>
{

}