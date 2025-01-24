using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Vector3 moveDirection;

    public GameObject bulletPrefab;

    private float timer;
    public float timeBetweenShots = 0.2f;


    void Update()
    {
        moveDirection.z = Input.GetAxis("Vertical");
        moveDirection.x = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);

        timer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timer <= 0)
        {
            timer = timeBetweenShots;
            FireWeapon();

        }
    }

    private void FireWeapon()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

}
