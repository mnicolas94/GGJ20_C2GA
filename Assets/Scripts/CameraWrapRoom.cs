using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraWrapRoom : MonoBehaviour
{
    public Bounds roomBounds;
    public Camera cam;
    public float padding;

    void Start()
    {
//        WrapRoom();
    }

    [NaughtyAttributes.Button()]
    public void WrapRoom()
    {
        var pos = roomBounds.center;
        pos.z = cam.transform.position.z; 
        cam.transform.position = pos;

        float bwidth = roomBounds.extents.x + padding;
        float bheight = roomBounds.extents.y + padding;
        float aspect = cam.aspect;
        if (bheight * aspect < bwidth)
        {
            cam.orthographicSize = bwidth / aspect;
        }
        else
        {
            cam.orthographicSize = bheight;
        }
    }
}
