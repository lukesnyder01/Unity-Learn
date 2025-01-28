using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Vector3 moveDirection;

    public GameObject bulletPrefab;

    private float timer;
    public float timeBetweenShots = 0.2f;


    void Update()
    {
        moveDirection.z = Input.GetAxisRaw("Vertical");
        moveDirection.x = Input.GetAxisRaw("Horizontal");

        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);

        moveDirection = new Vector3(0, 0, 0);



        timer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timer <= 0)
        {
            timer = timeBetweenShots;
            FireWeapon(0f);
            FireWeapon(10f);
            FireWeapon(-10f);
            FireWeapon(20f);
            FireWeapon(-20f);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FireWeapon(float fireAngle)
    {
        Vector3 forwardVector = transform.forward;
        Quaternion rotation = transform.rotation * Quaternion.Euler(0, fireAngle, 0);
        Instantiate(bulletPrefab, transform.position, rotation);
    }

}
