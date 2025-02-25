using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMovement : MonoBehaviour
{
    public float velocidad = 2f; 
    private Vector2 offset;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.mainTextureOffset;
    }

    void Update()
    {
        offset.x += velocidad * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
