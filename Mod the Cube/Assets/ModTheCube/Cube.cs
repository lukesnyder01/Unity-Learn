using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    float rotationSpeed = 30f;


    float scaleSpeed = 8f;
    float scaleAmount = 8f;

    private Vector3 defaultScale = new Vector3(2f, 5f, 10f);

    private Rigidbody rigidBody;


    float timer;
    float maxTimer = 0.5f;

    void Start()
    {
        SetTimer();
        rigidBody = transform.GetComponent<Rigidbody>();

        Material material = gameObject.GetComponent<MeshRenderer>().material;

        material.color = Random.ColorHSV();

        transform.rotation = Random.rotation;
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        


        if (timer <= 0)
        {
            SetTimer();
            AddRandomForce();
        }

        RotateCube();
        ChangeCubeScale();
    }

    void SetTimer()
    {
        timer = maxTimer;
    }

    void RotateCube()
    {
        transform.Rotate(Random.Range(30, 200) * Time.deltaTime, 0.0f, 0.0f);
    }

    void ChangeCubeScale()
    {
        var targetScaleMultiplier = (Mathf.Sin(Time.time * scaleSpeed) + 8) / scaleAmount;
        transform.localScale = defaultScale * targetScaleMultiplier;
    }

    void AddRandomForce()
    {
        Vector3 randomDirection = Random.insideUnitSphere;
        Vector3 targetRandomForce = randomDirection * 20;
        rigidBody.AddForce(Vector3.up * 5 + targetRandomForce, ForceMode.Impulse);
    }


}
