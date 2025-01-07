using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10f;

    private float leftBound = -15f;

    private PlayerController playerControllerScript;

    private bool isObstacle;

    void Start()
    {
        isObstacle = gameObject.CompareTag("Obstacle");

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x <= leftBound && isObstacle)
        {
            Destroy(gameObject);
        }

    }
}
