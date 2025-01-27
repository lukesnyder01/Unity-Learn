using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 15f;
    private float bottomBound = -15f;


    void Update()
    {
        if (transform.position.z > topBound)
        {
            ObjectPooler.Instance.ReturnObject(gameObject);
        }
        if (transform.position.z < bottomBound)
        {
            ObjectPooler.Instance.ReturnObject(gameObject);
        }    
    }
}
