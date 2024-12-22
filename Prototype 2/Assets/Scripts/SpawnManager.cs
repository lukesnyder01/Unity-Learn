using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 35;

    private float timer;
    private float minSpawnTime = 0.4f;
    private float maxSpawnTime = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        SetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SetTimer();
            SpawnRandomAnimal();
        }
    }

    void SetTimer()
    {
        timer = Random.Range(minSpawnTime, maxSpawnTime);
    }


    void SpawnRandomAnimal()
    {
        var index = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[index], spawnPos, animalPrefabs[index].transform.rotation);

    }

}
