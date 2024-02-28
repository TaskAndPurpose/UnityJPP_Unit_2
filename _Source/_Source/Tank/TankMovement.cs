using UnityEngine;

public class TankMovementCore : MonoBehaviour
{
    public Rigidbody _rb;

    // Movement variables
    public float _speed = 12f; // Movement speed
    public float _turnSpeed = 180f; // Turn speed

    void Start()
    {
        // Get the Rigidbody component attached to the tank
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calculate rotation based on input
        float rotation = CalculateRotation();

        // Rotate the tank
        RotateTank(rotation);
    }

    void FixedUpdate()
    {
        // Calculate horizontal movement based on input
        float horizontalMovement = CalculateHorizontalMovement();

        // Calculate vertical movement based on input
        float verticalMovement = CalculateVerticalMovement();

        // Move the tank
        MoveTank(verticalMovement, horizontalMovement);
    }

    float CalculateRotation()
    {
        float rotation = 0f;
        if (Input.GetKey(KeyCode.Q))
            rotation = -_turnSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.E))
            rotation = _turnSpeed * Time.deltaTime;
        return rotation;
    }

    float CalculateHorizontalMovement()
    {
        float horizontalMovement = 0f;
        if (Input.GetKey(KeyCode.A))
            horizontalMovement = -_speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.D))
            horizontalMovement = _speed * Time.deltaTime;
        return horizontalMovement;
    }

    float CalculateVerticalMovement()
    {
        float verticalMovement = 0f;
        if (Input.GetKey(KeyCode.W))
            verticalMovement = _speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            verticalMovement = -_speed * Time.deltaTime;
        return verticalMovement;
    }

    void MoveTank(float verticalMovement, float horizontalMovement)
    {
        // Calculate movement direction based on input
        Vector3 movementDirection = transform.forward * verticalMovement;

        // Move the tank based on the calculated movement direction
        _rb.MovePosition(_rb.position + movementDirection);

        // Apply horizontal movement by moving the tank's position along its right vector
        transform.Translate(transform.right * horizontalMovement, Space.World);
    }

    void RotateTank(float rotation)
    {
        // Rotate the tank based on the calculated rotation
        transform.Rotate(0f, rotation, 0f);
    }
    
}
