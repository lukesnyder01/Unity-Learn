using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    private float spawnPosZ = 14f;
    private float spawnWidth = 24f;
    private int numberOfSpawnPoints = 16;

    private List<Vector3> spawnPositions = new List<Vector3>();

    private float timeBetweenSpawns = 0.5f;
    private float timer;

    public GameObject asteroidPrefab;
    private int spawnIndex = 0;

    private bool[] currentCellStates;
    private bool[] nextCellStates;

    void Start()
    {
        InitializeCells();

        SetSpawnPoints();

    }


    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = timeBetweenSpawns;
            SpawnAsteroid();
        }
    }

    private void InitializeCells()
    {
        currentCellStates = new bool[numberOfSpawnPoints];
        nextCellStates = new bool[numberOfSpawnPoints];

        for (int i = 0; i < currentCellStates.Length; i++)
        {
            currentCellStates[i] = Random.Range(0, 1) > 0.5;
        }

        Debug.Log(currentCellStates);
    }

    private void SetSpawnPoints()
    {
        // Fill spawn point list with spawn points
        // Start from the left and move to the right

        float startX = - (spawnWidth / 2);
        float distanceBetweenSpawns = spawnWidth / numberOfSpawnPoints;

        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            float spawnX = startX + (distanceBetweenSpawns * i);
            Vector3 spawnPos = new Vector3(spawnX, 0f, spawnPosZ);

            spawnPositions.Add(spawnPos);
        }
    }



    void SpawnAsteroid()
    {
        Instantiate(asteroidPrefab, spawnPositions[spawnIndex % spawnPositions.Count], transform.rotation);
        spawnIndex++;
    }
}

