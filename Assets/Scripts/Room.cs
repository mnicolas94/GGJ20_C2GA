using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Bounds bounds;
    public DancerNumberSpawn dancersNumberSpawn;    
    
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
        foreach (var prefabDancer in dancersNumberSpawn.Keys)
        {
            for (int i = 0; i < dancersNumberSpawn[prefabDancer]; i++)
            {
                Vector2 randomPos = bounds.RandomPos();
                var go = GameObject.Instantiate(prefabDancer, randomPos, Quaternion.identity);
                var rmc = go.GetComponent<RandomMovementController>();
                rmc.areaToMove = bounds;
            }
        }
    }
}

[System.Serializable()]
public class DancerNumberSpawn : SerializableDictionaryBase<GameObject, int>
{

}
