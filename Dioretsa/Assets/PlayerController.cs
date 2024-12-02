using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Vector3 moveDirection;


    void Update()
    {
        moveDirection.z = Input.GetAxis("Vertical");
        moveDirection.x = Input.GetAxis("Horizontal");



        // move the plane forward at a constant rate
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);



    }
}
