using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DrivingMechanic : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float acceleration = 5f;
    public float deceleration = 8f;
    public float turnSpeed = 200f;

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
        // Input fra W/S eller piltaster opp/ned
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = -Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        // H�ndter akselerasjon og bremsing
        if (moveInput != 0)
        {
            if (Mathf.Sign(moveInput) == Mathf.Sign(currentSpeed))
            {
                // Akselerer i samme retning
                currentSpeed += moveInput * acceleration * Time.fixedDeltaTime;
            }
            else
            {
                // Brems ned
                currentSpeed += moveInput * deceleration * Time.fixedDeltaTime;
            }
        }
        else
        {
            // Gradvis brems til stillstand
            if (Mathf.Abs(currentSpeed) > 0.01f)
            {
                currentSpeed -= Mathf.Sign(currentSpeed) * deceleration * Time.fixedDeltaTime;
            }
            else
            {
                currentSpeed = 0f;
            }
        }

        // Begrens farten til maksverdi
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Flytt bilen
        rb.linearVelocity = transform.up * currentSpeed;

        // Roter bilen bare hvis den beveger seg
        if (Mathf.Abs(currentSpeed) > 0.1f)
        {
            rb.MoveRotation(rb.rotation + turnInput * turnSpeed * Time.fixedDeltaTime);
        }
    }
}