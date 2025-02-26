using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMovement : MonoBehaviour
{
    [SerializeField] private float velocidad = 2f;

    private Vector2 offset;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material; //Toma el sprite renderer del gameobject
        offset = material.mainTextureOffset;
    }

    void Update()
    {
        MoveImage();
    }
    void MoveImage()
    {
        offset.x += velocidad * Time.deltaTime; //mueve la imagen hacia la izquierda infinitamente
        material.mainTextureOffset = offset;
    }
}
