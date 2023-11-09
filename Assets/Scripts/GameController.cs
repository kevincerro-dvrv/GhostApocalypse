using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ghostPrefab;
    private Vector3[] spawnPoints = {
        new Vector3(-10f, 2.45f, 0f),
        new Vector3(-10f, 1.66f, 0f),
        new Vector3(-10f, 0f, 0f),
        new Vector3(-10f, -1.24f, 0f),
        new Vector3(-10f, -3.14f, 0f)
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float random = Random.Range(0f, 1f);
        if (random < 0.001f) {
            SpawnGhost();
        }   
    }

    private void SpawnGhost()
    {
        Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(ghostPrefab, spawnPoint, Quaternion.identity);
    }
}
