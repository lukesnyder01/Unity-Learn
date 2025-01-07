using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator playerAnimator;

    public float jumpForce = 10f;
    public float gravityModifier = 1.5f;

    private bool playerGrounded;

    public bool gameOver = false;




    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        playerAnimator = transform.GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerGrounded)
        {
            if (!gameOver)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerGrounded = false;
        playerAnimator.SetTrigger("Jump_trig");
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            EndGame();
        }
    }


    private void EndGame()
    {
        gameOver = true;
        Debug.Log("Game Over");
        playerAnimator.SetBool("Death_b", true);
        playerAnimator.SetInteger("DeathType_int", 1);
    }

}
