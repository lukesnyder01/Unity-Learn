using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float forwardInput;

    public GameObject powerupIndicator;

    public Transform focalPointTransform;
    public float speed = 5f;

    public bool hasPowerup = false;
    private float powerupStregth = 20f;

    float powerupTimer;
    float timePerPowerup = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        rigidBody.AddForce(focalPointTransform.forward * speed * forwardInput);

        powerupIndicator.transform.position = transform.position;

        powerupTimer -= Time.deltaTime;
        if (powerupTimer <= 0f)
        {
            powerupTimer = 0f;
            hasPowerup = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            powerupTimer += timePerPowerup;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 dirAwayFromPlayer = (collision.transform.position - transform.position);
            enemyRb.AddForce(dirAwayFromPlayer * powerupStregth, ForceMode.Impulse);
        }
    }

}
