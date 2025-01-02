using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float verticalBound = 40;

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.z) > verticalBound)
        {
            if (transform.position.z < verticalBound)
            {
                Debug.Log("Game Over!");
            }

            Destroy(gameObject);
        }
    }
}
