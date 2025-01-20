using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 40f;
    private float horizontalInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, -1 * horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
