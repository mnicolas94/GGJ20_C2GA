using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utiles;

public class BackgroundInit : MonoBehaviour
{
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        OrtoCamUtilities.MatchSize(cam, GetComponent<SpriteRenderer>(), true, true);
    }
}
