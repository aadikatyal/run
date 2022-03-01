using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    GameObject sphere;
    public GameObject cam;

    void Start()
    {
        sphere = GameObject.Find("Sphere");
    }

    void Update()
    {
        transform.position = new Vector3(sphere.transform.position.x, 2.0f, sphere.transform.position.z - 5.0f);
        cam.transform.Rotate(6.0f, 0.0f, 0.0f, Space.World);
        transform.LookAt(sphere.transform);
    }
}