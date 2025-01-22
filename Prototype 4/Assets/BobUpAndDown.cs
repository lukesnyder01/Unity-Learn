using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobUpAndDown : MonoBehaviour
{
    public float speed = 5;
    public float distance = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * distance;

        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}
