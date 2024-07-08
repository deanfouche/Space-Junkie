using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }
}
