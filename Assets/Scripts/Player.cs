using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private float _horizontalBoundary = 11.4f;
    private float _bottomBoundary = -1f;
    private float _topBoundary = 6f;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private int _firingDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial position
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        ShootLaser();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);


        // Bounds for player y pos
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _bottomBoundary, _topBoundary), 0);

        // Wrapping bounds for player x pos
        if (transform.position.x > _horizontalBoundary)
        {
            Vector3 newXPos = new Vector3(-_horizontalBoundary, transform.position.y, transform.position.z);
            transform.position = newXPos;
        }
        else if (transform.position.x < -_horizontalBoundary)
        {
            Vector3 newXPos = new Vector3(_horizontalBoundary, transform.position.y, transform.position.z);
            transform.position = newXPos;
        }
    }

    void ShootLaser()
    {
        if (Input.GetKey(KeyCode.Space) && _firingDelay == 0)
        {
            _firingDelay = 10;
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        }
        
        if (_firingDelay > 0)
        {
            _firingDelay--;
        }
    }
}
