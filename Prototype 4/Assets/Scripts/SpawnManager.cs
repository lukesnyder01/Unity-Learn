using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float timer;
    public float timeBetweenSpawns = 1f;

    public float spawnRange = 4f;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = timeBetweenSpawns;

            Instantiate(enemyPrefab, SpawnPointInCircle(), Quaternion.identity);
        }

    }


    private Vector3 SpawnPointInCircle()
    {
        transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
        Debug.Log(transform.position + (transform.forward * spawnRange));
        return transform.position + (transform.forward * spawnRange);
    }
}
