using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Bounds bounds;
    public GameObject dancerPrefab;
    public int spawnedNumber = 0; 

    // Start is called before the first frame update
    void Start()
    {
        this.Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        for (int i = 0; i < spawnedNumber; i++)
        {
            Vector2 randomPos = bounds.RandomPos();
            GameObject.Instantiate(dancerPrefab, randomPos, Quaternion.identity);
        }
    }
}
