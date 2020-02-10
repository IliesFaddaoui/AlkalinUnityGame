using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLight : MonoBehaviour
{
    public GameObject light;
    public float rotationSpeed = 10.0f;
    float timeCounter= 0;
    float height = 40;
    float speed= 5;
    float width = 40;
    private void Start()
    {

    }
    void Update()
    {
        timeCounter += Time.deltaTime * speed;

        float x = Mathf.Cos(timeCounter)*width;
        float y = 57.8f;
        float z = Mathf.Sin(timeCounter)*height;

        light.transform.position = new Vector3(x, y, z);
    }
}
