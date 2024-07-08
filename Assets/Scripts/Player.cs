using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial position
        transform.position = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);


        // Bounds for player y pos
        if (transform.position.y >= 6)
        {
            Vector3 newYPos = new Vector3(transform.position.x, 6, transform.position.z);
            transform.position = newYPos;
        } else if (transform.position.y <= -1)
        {
            Vector3 newYPos = new Vector3(transform.position.x, -1, transform.position.z);
            transform.position = newYPos;
        }

        // Bounds for player x pos
        if (transform.position.x > 15)
        {
            Vector3 newXPos = new Vector3(-15.0f, transform.position.y, transform.position.z);
            transform.position = newXPos;
        }
        else if (transform.position.x < -15)
        {
            Vector3 newXPos = new Vector3(15f, transform.position.y, transform.position.z);
            transform.position = newXPos;
        }
    }
}
