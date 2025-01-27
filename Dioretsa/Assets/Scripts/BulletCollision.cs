using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Asteroid"))
        {
            ObjectPooler.Instance.ReturnObject(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
