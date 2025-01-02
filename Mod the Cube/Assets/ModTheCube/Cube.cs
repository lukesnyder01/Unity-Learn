using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    float rotationSpeed = 30f;


    float bounceSpeed = 8f;
    float bounceScale = 8f;

    private Vector3 defaultScale = new Vector3(3f, 3f, 3f);

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        RotateCube();
        ChangeCubeScale();
    }


    void RotateCube()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    void ChangeCubeScale()
    {
        var targetScaleMultiplier = (Mathf.Sin(Time.time * bounceSpeed) + 8) / bounceScale;
        transform.localScale = defaultScale * targetScaleMultiplier;
    }


}
