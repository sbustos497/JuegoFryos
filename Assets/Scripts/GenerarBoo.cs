using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarBoo : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int minSpawnCount = 1;
    public int maxSpawnCount = 5;

   public  int spawnCount;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
       spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);

        Camera gameCamera = Camera.main;
        float camHeight = 2f * gameCamera.orthographicSize;
        float camWidth = camHeight * gameCamera.aspect;
        Debug.Log(spawnCount);

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-camWidth / 2f, camWidth / 2f),
                0f,
                Random.Range(-camHeight / 2f, camHeight / 2f)
            );

            Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 0f), 0f);

            GameObject newObject = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
            // Puedes realizar acciones adicionales con 'newObject' si es necesario
        }
    }
}

