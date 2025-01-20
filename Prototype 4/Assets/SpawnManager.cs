using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float timer;
    public float timeBetweenSpawns = 1f;

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

            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }

    }
}
