using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public int enemyCount;

    private float timer;
    public float timeBetweenSpawns = 5f;

    private int waveCount = 1;

    public float spawnRange = 4f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
            SpawnPowerup();
            waveCount++;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = timeBetweenSpawns;


        }

    }


    private Vector3 SpawnPointInCircle()
    {
        transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
        return transform.position + (transform.forward * spawnRange);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, SpawnPointInCircle(), Quaternion.identity);
        }
    }

    private void SpawnPowerup()
    {
        Vector3 spawnPoint = SpawnPointInCircle();
        spawnPoint.y = 0.5f;



        Instantiate(powerupPrefab, spawnPoint, Quaternion.identity);
    }

}
