using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue;

    public ParticleSystem exploxionParticles;

    private Rigidbody rb;
    private GameManager gameManager;

    private float minForce = 12;
    private float maxForce = 15;

    private float minTorque = -10;
    private float maxTorque = 10;

    private float xSpawnRange = 4;
    private float ySpawnPos = -2;



    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(exploxionParticles, transform.position, transform.rotation);
            gameManager.AddScore(scoreValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

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
