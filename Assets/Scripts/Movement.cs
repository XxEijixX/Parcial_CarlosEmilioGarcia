using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform groundCheck; // Transform que representa el área de detección de suelo
    [SerializeField] private LayerMask groundLayer; // Layer del suelo
    [SerializeField] private float jumpForce = 5f; // Fuerza del salto
    [SerializeField] private float crouchHeight = 1f; // Altura cuando el personaje está agachado
    [SerializeField] private float standingHeight = 2f; // Altura normal del personaje
    [SerializeField] private float groundDistance = 0.2f; // Distancia para detectar el suelo

    private Rigidbody rb; // Componente Rigidbody
    private CapsuleCollider capsuleCollider; // Componente CapsuleCollider
    private Vector3 originalScale; // Escala original del personaje
    private bool isGrounded; // Verifica si esta tocando el suelo

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>(); // Usando el Capsule Colider
        originalScale = transform.localScale; // Se guarda la escala original

        rb.freezeRotation = true; // Evita que el rigid body gire al momento del contacto
    }

    private void Update()
    {
        CheckGround(); 
        Jump();
        Crouch();
    }

    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer); 
    }
    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // Salto con la tecla espacio
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        }
    }
    private void Crouch()
    {
        if (Input.GetKey(KeyCode.C)) // Si se presiona la tecla C, el personaje se "agacha"
        {
            capsuleCollider.height = crouchHeight; // Comprime el CapsuleCollider en el eje Y
            transform.localScale = new Vector3(originalScale.x, 0.2f, originalScale.z); // Solo afecta la escala en eje Y
        }
        else
        {
            capsuleCollider.height = standingHeight; // Restablece el tamaño original del CapsuleCollider
            transform.localScale = originalScale; // Vuelve a la escala original
        }
    }
}
