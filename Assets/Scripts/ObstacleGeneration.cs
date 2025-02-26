using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab; // Prefab del cubo

    [SerializeField] private float spawnRate = 2f; // Tiempo entre spawns
    [SerializeField] private float minY = 0f, maxY = 5f; // Rango en Y donde se generan
    [SerializeField] private float minZ = -5f, maxZ = 5f; // Rango en Z donde se generan
    [SerializeField] private float cubeSpeed = 5f; // Velocidad del cubo

    private void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    IEnumerator SpawnCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate); //La espera de segundos antes de spawnear otro cubo
            SpawnCube();
        }
    }

    void SpawnCube()
    {
        float randomY = Random.Range(minY, maxY); // Posición aleatoria en Y
        float randomZ = Random.Range(minZ, maxZ); // Posición aleatoria en Z
        Vector3 spawnPosition = new Vector3(10f, randomY, randomZ); // Genera los cubos en Y y Z aleatorio

        GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
        cube.AddComponent<Rigidbody>().useGravity = false; // Desactivar gravedad
        cube.AddComponent<BoxCollider>(); // Agrega colision
        CubeMovement movement = cube.AddComponent<CubeMovement>(); // Agregar movimiento
        movement.speed = cubeSpeed; 
    }
}

public class CubeMovement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // Moverse a la izquierda en X
    }
}
