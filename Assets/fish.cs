using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Maximum speed
    public float acceleration = 10f;  // How quickly it reaches max speed
    public float deceleration = 10f;  // How quickly it slows down
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Get input
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxisRaw("Vertical");     // W/S or Up/Down

        Vector3 inputDir = new Vector3(horizontal, 0, vertical).normalized;

        // Smoothly accelerate to target velocity
        if (inputDir.magnitude > 0)
        {
            velocity = Vector3.MoveTowards(velocity, inputDir * moveSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            // Smoothly decelerate to stop
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, deceleration * Time.deltaTime);
        }

        // Move the object
        transform.Translate(velocity * Time.deltaTime, Space.World);
    }
}
