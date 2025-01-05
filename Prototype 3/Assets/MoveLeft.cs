using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
