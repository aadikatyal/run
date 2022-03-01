using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    float time;
    public GameObject cube;
    int planeCounter;

    void Start()
    {
        time = 0.0f;
        planeCounter = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 1.0f)
        {
            planeCounter++;
            time = 0.0f;

            for (int i = 1; i <= 2; i++)
            {
                createMap(i, 25.0f, 0.0f, new Vector3(1.0f, 1.0f, 2.0f));
            }
        }
    }

    void createMap(int type, float gapMultiplier, float xPos, Vector3 scale)
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        float yPosCube;

        if (type == 1)
        {
            plane.transform.position = new Vector3(xPos, 0f, planeCounter * gapMultiplier);
            yPosCube = 0.5f;
        }
        else
        {
            plane.transform.position = new Vector3(xPos, 5f, planeCounter * gapMultiplier);
            plane.transform.eulerAngles = new Vector3(180f, 0f, 0f);
            yPosCube = 4.5f;
        }

        plane.transform.localScale = scale;

        int cubeCount = 0;

        while (cubeCount < 4)
        {
            GameObject newCube = Instantiate(cube, new Vector3(Random.Range(-5.0f, 5.0f), yPosCube, Random.Range(plane.transform.position.z - 5.0f, plane.transform.position.z + 5.0f)), Quaternion.identity);
            cubeCount++;
        }
    }
}