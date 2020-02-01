using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action eventGameEnded;

    public void LoseGame()
    {
        eventGameEnded?.Invoke();
    }
}
