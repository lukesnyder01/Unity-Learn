using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    private int[] lookup = new int[8];

    private float spawnPosZ = 14f;
    public float spawnWidth = 100f;
    public int numberOfSpawnPoints = 20;

    private List<Vector3> spawnPositions = new List<Vector3>();

    public float timeBetweenSpawns = 1f;
    private float timer;

    public GameObject asteroidPrefab;

    private bool[] currentCellStates;
    private bool[] nextCellStates;


    void Start()
    {
        lookup[0b000] = 0;
        lookup[0b001] = 1;
        lookup[0b010] = 0;
        lookup[0b011] = 1;
        lookup[0b100] = 1;
        lookup[0b101] = 0;
        lookup[0b110] = 1;
        lookup[0b111] = 0;

        InitializeCells();

        SetSpawnPoints();

    }


    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = timeBetweenSpawns;
            CalculateNextCells();
            Spawn();
        }

        if (Input.GetKey(KeyCode.R))
        {
            RandomizeRule();
        }

        if (Input.GetKey(KeyCode.T))
        {
            RandomizeBuffer();
        }

        if (Input.GetKey(KeyCode.Y))
        {
            ResetBuffer();
        }
    }

    private void InitializeCells()
    {
        currentCellStates = new bool[numberOfSpawnPoints];
        nextCellStates = new bool[numberOfSpawnPoints];

        ResetBuffer();
    }

    private void CalculateNextCells()
    {
        // Loop through each cell in the current cells
        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            // Look at each 3 bit neighborhood including wrapping to the other side

            int left = currentCellStates[(i - 1 + numberOfSpawnPoints) % numberOfSpawnPoints] ? 1 : 0;
            int middle = currentCellStates[i] ? 1 : 0;
            int right = currentCellStates[(i + 1) % numberOfSpawnPoints] ? 1 : 0;

            // Turn that into a 3 bit integer
            int pattern = (left << 2) | (middle << 1) | right;

            if (lookup[pattern] == 1)
            {
                nextCellStates[i] = true;
            }
            else
            {
                nextCellStates[i] = false;
            }
        }


    }


    private void Spawn()
    {
        // Loop through each cell and spawn asteroids
        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            currentCellStates[i] = nextCellStates[i];
            nextCellStates[i] = false;

            if (currentCellStates[i])
            {
                Vector3 spawnPos = spawnPositions[i];

                GameObject asteroid = ObjectPooler.Instance.GetObject();
                asteroid.transform.position = spawnPos;
            }
        }
    }

    private void SetSpawnPoints()
    {
        // Fill spawn point list with spawn points
        // Start from the left and move to the right

        float startX = -(spawnWidth / 2);
        float distanceBetweenSpawns = spawnWidth / numberOfSpawnPoints;

        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            float spawnX = startX + (distanceBetweenSpawns * i);
            Vector3 spawnPos = new Vector3(spawnX, 0f, spawnPosZ);

            spawnPositions.Add(spawnPos);
        }
    }

    private void RandomizeRule()
    {
        for (int i = 0; i < lookup.Length; i++)
        {
            if (Mathf.Floor(Random.Range(0, 100)) < 50)
            {
                lookup[i] = 1;
            }
            else
            {
                lookup[i] = 0;
            }
        }
    }

    private void RandomizeBuffer()
    {
        for (int i = 0; i < currentCellStates.Length; i++)
        {
            if (Mathf.Floor(Random.Range(0, 100)) < 50)
            {
                currentCellStates[i] = true;
            }
            else
            {
                currentCellStates[i] = false;
            }
            
        }
    }

    private void ResetBuffer()
    {
        for (int i = 0; i < currentCellStates.Length; i++)
        {

            if (i == Mathf.Floor(currentCellStates.Length / 2))
            {
                currentCellStates[i] = true;
            }
            else
            {
                currentCellStates[i] = false;
            }
        }
    }

}

