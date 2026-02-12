using UnityEngine;

public class SmoothSideMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Maximum speed
    public float acceleration = 10f;   // How quickly it reaches max speed
    public float deceleration = 10f;   // How quickly it slows down
    private Vector2 velocity = Vector2.zero;

    void Update()
    {
        // WASD input (A/D = horizontal, W/S = vertical)
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D
        float vertical = Input.GetAxisRaw("Vertical");     // W/S

        Vector2 inputDir = new Vector2(horizontal, vertical).normalized;

        // Accelerate toward input
        if (inputDir.magnitude > 0)
        {
            velocity = Vector2.MoveTowards(velocity, inputDir * moveSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            // Decelerate to stop
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, deceleration * Time.deltaTime);
        }

        // Move object
        transform.Translate(velocity * Time.deltaTime);
    }
}
