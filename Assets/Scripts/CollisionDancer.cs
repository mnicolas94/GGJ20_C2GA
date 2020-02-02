// using System;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class CollisionDancer : MonoBehaviour
{
    public Movement self;
    public float probabilityToDance;
    public float timeToRespond;
    
    public bool justOneDance;
    public KeyCode keyDance1;
    public KeyCode keyDance2;
    public Animator anim;


    private bool _onCollision;
    private KeyCode _keyToPress;
    private KeyCode _keyNotPress;
    private string danceToDance;
    private float _timeToStop;
    private Movement _playerMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (canDance())  // decidir aleatoriamente si bailar o no
            {
                _onCollision = true;
                // detener a los 2 players
                this.stopPlayers(other);
                
                // decidir tipo de baile
                if (Random.Range(0, 2) == 0 || justOneDance)
                {
                    _keyToPress = keyDance1;
                    _keyNotPress = keyDance2;
                    danceToDance = "dance1";
                }
                else
                {
                    _keyToPress = keyDance2;
                    _keyNotPress = keyDance1;
                    danceToDance = "dance2";
                }
                anim.SetTrigger(danceToDance);
                
                SpotLights(true);
                _timeToStop = Time.time + timeToRespond;
            }
        }
    }

    private void Update() {
        if (_onCollision)
        {
            if(_timeToStop <= Time.time)
            {
                EndDancing();
                GameManager.instance.LoseGame();
            } else if (Input.GetKeyDown(_keyToPress))
            {
                _onCollision = false;
                // poner a bailar al player
                _playerMovement.GetComponent<Animator>().SetTrigger(danceToDance);
                // victoria en el baile
                Invoke("EndDancing", timeToRespond);
            } else if (Input.GetKeyDown(_keyNotPress))
            {
                EndDancing();
                GameManager.instance.LoseGame();
            }
        }
    }

    private void EndDancing()
    {
        _onCollision = false;
        anim.SetTrigger("stopDancing");
        _playerMovement.GetComponent<Animator>().SetTrigger("stopDancing");
        self.enabled = true;
        _playerMovement.enabled = true;
        SpotLights(false);
    }

    private void SpotLights(bool on)
    {
        GameManager.instance.whiteLight.gameObject.SetActive(!on);
//        GameManager.instance.colorLight.gameObject.SetActive(!on);
        GameManager.instance.spotLight.gameObject.SetActive(on);
        if (on)
        {
            var newpos = (_playerMovement.transform.position + self.transform.position) / 2;
            newpos.z = GameManager.instance.spotLight.position.z;
            GameManager.instance.spotLight.position = newpos;
        }
    }
    
    private bool canDance()
    {
        return Random.value < probabilityToDance;
    }

    private void stopPlayers(Collider2D other)
    {
        _playerMovement = other.GetComponent<Movement>();
        _playerMovement.Move(Vector2.zero);
        _playerMovement.enabled = false;
        
        self.Move(Vector2.zero);
        self.enabled = false;
    }
}

[System.Serializable()]
public class KeyAnimationDict: SerializableDictionaryBase<KeyCode, string>
{

}