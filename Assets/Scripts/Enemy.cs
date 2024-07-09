using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _ySpeed = 4.0f;
    [SerializeField]
    private float _xSpeed = 5.0f;
    [SerializeField]
    private float _xMinMax = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 9, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        // If x position is greater/less than max/min boundary, increment toward opposite boundary
        if (transform.position.x >= _xMinMax || transform.position.x <= -_xMinMax)
        {
            _xSpeed = _xSpeed * -1.0f;
        }

        // Move left and right within boundary
        transform.Translate(Vector3.right * _xSpeed * Time.deltaTime);


        // Move down at current speed
        transform.Translate(Vector3.down * _ySpeed * Time.deltaTime);

        //If at bottom, respawn at top
        if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(Random.Range(-4.0f, 4.0f), 9, 0);
        }
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        // If other is player
        // damage player
        // and destroy us
        if (otherObject.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        // If other is laser
        // destroy laser
        // and destroy us
        if (otherObject.transform.tag == "Laser")
        {
            Destroy(otherObject);
            Destroy(this.gameObject);
        }
    }
}
