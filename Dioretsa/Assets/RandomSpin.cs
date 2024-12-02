using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpin : MonoBehaviour
{
    private Vector3 randomSpin;
    private float maxSpeed = 20f;
    private float minSpeed = 2f;


    void Start()
    {
        // Randomize initial rotation
        transform.rotation = Random.rotation;

        // Set a random speed to spin in each axis
        randomSpin.x = Random.Range(minSpeed, maxSpeed);
        randomSpin.y = Random.Range(minSpeed, maxSpeed);
        randomSpin.z = Random.Range(minSpeed, maxSpeed);
    }

 
    void Update()
    {
        // Apply random rotation
        transform.Rotate(randomSpin * Time.deltaTime);
    }
}
