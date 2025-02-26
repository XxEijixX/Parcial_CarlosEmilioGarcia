using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class RestartScene : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision) 
    {
        
        if (collision.gameObject.CompareTag("Obstacle")) // Verifica si el objeto con el que chocamos tiene el tag "Obstacle"
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Se reinicia la escena cuando haga contacto con el jugador.
        }
    }
}
