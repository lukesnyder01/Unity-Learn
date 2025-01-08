using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator playerAnimator;

    public float jumpForce = 10f;
    public float gravityModifier = 1.5f;

    public ParticleSystem smokeParticles;
    public ParticleSystem dirtParticles;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private bool playerGrounded;

    public bool gameOver = false;

    private AudioSource playerAudio;





    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        playerAnimator = transform.GetComponent<Animator>();
        playerAudio = transform.GetComponent<AudioSource>();
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
        dirtParticles.Stop();
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerGrounded = false;
        playerAnimator.SetTrigger("Jump_trig");
        playerAudio.PlayOneShot(jumpSound, 1.0f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerGrounded = true;
            dirtParticles.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            EndGame();
            dirtParticles.Stop();
        }
    }


    private void EndGame()
    {
        gameOver = true;
        Debug.Log("Game Over");
        playerAnimator.SetBool("Death_b", true);
        playerAnimator.SetInteger("DeathType_int", 1);
        smokeParticles.Play();
    }

}
