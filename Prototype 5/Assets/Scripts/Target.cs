using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;

    private float minForce = 12;
    private float maxForce = 15;

    private float minTorque = -10;
    private float maxTorque = 10;

    private float xSpawnRange = 4;
    private float ySpawnPos = -4;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    float RandomTorque()
    {
        return Random.Range(minTorque, maxTorque);
    }

    Vector3 RandomSpawnPosition()
    { 
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos, 0);
    }

}
