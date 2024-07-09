using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    private float _horizontalBoundary = 11.4f;
    private float _bottomBoundary = -1.0f;
    private float _topBoundary = 6.0f;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _firingDelay = 0;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _nextFire = 0.0f;

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
        FiringLogic();
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

    void FiringLogic()
    {
        // First implementation
        /*
            if (Input.GetKey(KeyCode.Space) && _firingDelay == 0)
            {
                _firingDelay = 10;
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
            }
        
            if (_firingDelay > 0)
            {
                _firingDelay--;
            }
        */

        // Second implementation
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
        }
    }
}
