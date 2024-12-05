using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    private float minTimeBetweenSpawns = 2f;
    private float maxTimeBetweenSpawns = 4f;
    private float timer;

    public GameObject asteroidPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            SetRandomTimer();
            SpawnAsteroid();
        }
    }


    void SetRandomTimer()
    {
        timer = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }

    void SpawnAsteroid()
    {
        Instantiate(asteroidPrefab, transform.position, transform.rotation);
    }
}

