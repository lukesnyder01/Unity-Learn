using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float timer;
    public float timeBetweenShots = 2f;

    void Start()
    {
        timer = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timer <= 0)
            {
                timer = timeBetweenShots;
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
        }
    }
}
