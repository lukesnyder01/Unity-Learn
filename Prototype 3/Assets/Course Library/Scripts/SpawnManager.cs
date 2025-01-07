using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstacle;
    private Vector3 spawnPos = new Vector3(25f, 0, 0);

    private float timer;
    private float maxTimeInterval = 1f;
    private float minTimeInterval = 0.5f;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }



    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f && playerControllerScript.gameOver == false)
        {
            timer = Random.Range(minTimeInterval, maxTimeInterval);
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }
}
