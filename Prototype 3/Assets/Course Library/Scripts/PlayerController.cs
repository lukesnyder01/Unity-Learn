using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpForce = 10f;
    private float gravityModifier = 1.5f;
    private bool playerGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerGrounded)
        {
            Jump();
        }

    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerGrounded = false;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        playerGrounded = true;
    }

}
