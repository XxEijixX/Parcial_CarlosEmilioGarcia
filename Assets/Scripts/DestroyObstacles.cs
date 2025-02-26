using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //Este se añade a un box collider con trigger
    {
        if (other.CompareTag("Obstacle")) // Si el objeto que entra en contacto tiene el tag "Obstacle"
        {
            Destroy(other.gameObject); // Destruye el objeto (cubo)
        }
    }
}
