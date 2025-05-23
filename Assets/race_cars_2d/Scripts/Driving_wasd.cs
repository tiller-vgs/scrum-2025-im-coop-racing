using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Driving_wasd : MonoBehaviour
{
    public float maxSpeed = 8f;
    public float acceleration = 6f;
    public float deceleration = 8f;
    public float turnSpeed = 150f;

    private Rigidbody2D rb;
    private float currentSpeed = 0f;
    private float moveInput;
    private float turnInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = 0f;
        if (Input.GetKey(KeyCode.W)) moveInput += 1f;
        if (Input.GetKey(KeyCode.S)) moveInput -= 1f;

        turnInput = 0f;
        if (Input.GetKey(KeyCode.A)) turnInput += 1f;
        if (Input.GetKey(KeyCode.D)) turnInput -= 1f;
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        if (moveInput != 0)
        {
            if (Mathf.Sign(moveInput) == Mathf.Sign(currentSpeed))
                currentSpeed += moveInput * acceleration * Time.fixedDeltaTime;
            else
                currentSpeed += moveInput * deceleration * Time.fixedDeltaTime;
        }
        else
        {
            float decelAmount = deceleration * Time.fixedDeltaTime;
            if (Mathf.Abs(currentSpeed) <= decelAmount)
                currentSpeed = 0f;
            else
                currentSpeed -= Mathf.Sign(currentSpeed) * decelAmount;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);
        rb.linearVelocity = transform.up * currentSpeed;

        if (Mathf.Abs(currentSpeed) > 0.1f)
        {
            float direction = Mathf.Sign(currentSpeed);
            rb.MoveRotation(rb.rotation + turnInput * turnSpeed * Time.fixedDeltaTime * direction);
        }
    }
}
