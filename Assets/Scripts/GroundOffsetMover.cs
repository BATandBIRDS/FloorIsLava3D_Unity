using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundOffsetMover : MonoBehaviour
{
    [SerializeField] Vector2 offset = new Vector2(.1f, .05f);
    Material lava;

    void Start()
    {
        lava = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        MoveOffset();
    }

    void MoveOffset()
    {
        if (lava.mainTextureOffset.y < 1) 
        {
            lava.mainTextureOffset += offset * Time.deltaTime;
        }
        else
        {
            lava.mainTextureOffset = Vector2.zero;
        }
        
    }
}
