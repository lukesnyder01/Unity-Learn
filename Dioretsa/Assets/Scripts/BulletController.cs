using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private float despawnZ = 20;

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
        if (transform.position.z > despawnZ)
        { 
            Destroy(this.gameObject);
        }
    }
}
