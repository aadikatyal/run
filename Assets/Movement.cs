using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    float moveSpeed = 8;
    Rigidbody rb;
    public GameObject sphere;
    float time, gravity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 0.0f;
        gravity = -15.0f;
    }

    void Update()
    {
        // forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        // left + right
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * 5 * Time.deltaTime);
        }

        // change gravity
        time += Time.deltaTime;
        if(Input.GetKey(KeyCode.Space) && time > 0.3f)
        {
            gravity = -gravity;
            Physics.gravity = new Vector3(0f, gravity, 0f);
            print(Physics.gravity);

            time = 0.0f;
        }

        // jump
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if((transform.position.y < 1 && transform.position.y > 0) && Physics.gravity.y < 0)
            {
                rb.AddForce(Vector3.up * 8.0f, ForceMode.Impulse);
            }

            if ((transform.position.y < 5 && transform.position.y > 4) && Physics.gravity.y > 0)
            {
                rb.AddForce(Vector3.down * 8.0f, ForceMode.Impulse);
            }
        }

        // check if sphere leaves bounds
        if(sphere.transform.position.y > 7 || sphere.transform.position.y < -2)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Cube"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}