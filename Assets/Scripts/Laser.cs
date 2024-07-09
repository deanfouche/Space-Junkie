using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        DetectCollision();
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    void DetectCollision()
    {
        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }
}
