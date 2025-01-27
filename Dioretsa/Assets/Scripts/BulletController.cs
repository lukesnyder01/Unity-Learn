using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletController : MonoBehaviour
{
    private float despawnZ = 20;
    private float speed = 15f;
    private Vector3 moveDirection;

    private void Start()
    {
        moveDirection = transform.forward;
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Asteroid"))
        {
            ObjectPooler.Instance.ReturnObject(other.gameObject);
            Destroy(this.gameObject);
        }
    }


    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        if (transform.position.z > despawnZ)
        { 
            Destroy(this.gameObject);
        }
    }
}
