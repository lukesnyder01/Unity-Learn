using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rigidBody;
    private Transform playerTransform;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        rigidBody.AddForce(directionToPlayer * speed);

        if (transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }
}
