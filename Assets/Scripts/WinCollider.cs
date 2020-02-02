using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Player")
        {
            GameManager.instance.LoseGame();
        }
    }
}
