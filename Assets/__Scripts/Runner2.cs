using UnityEngine;
using System.Collections;

public class Runner2 : MonoBehaviour
{
    private CharacterController characterController;
    private Rigidbody rb; // cache rigidbody reference
    GameObject legLeft, legRight;

    bool isRunning = false; // track if the runner is currently running

    float legMoveInterval = 0.15f; // time in seconds between leg movements
    float moveSpeed = 2f; // speed at which the runner moves forward

    float gravity = -9.81f; // gravity value
    Vector3 velocity; // store the velocity of the character
    float horizontalVelocity; // store horizontal movement speed
    bool wasGrounded; // track if the character was grounded in the previous frame
    bool ignoreGrounding;
    Vector3 savedVelocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        // get child leg objects
        legLeft = transform.Find("LegL").gameObject;
        legRight = transform.Find("LegR").gameObject;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set up a coroutine to move the legs at a given interval after 1 second delay
        Invoke("StartLegMovement", 1f);
    }

    void StartLegMovement()
    {
        isRunning = true;
        StartCoroutine(MoveLegs());
    }

    // Update is called once per frame
    void Update()
    {
        // Update horizontal velocity
       // horizontalVelocity = moveSpeed * Time.deltaTime;
        
        // Update horizontal velocity (store speed, not distance)
        horizontalVelocity = isRunning ? moveSpeed : 0f;
    }

    void FixedUpdate()
    {
        // Check if Runner has fallen below threshold
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
            return;
        }
        
        float dt = Time.fixedDeltaTime;

        // If CharacterController is disabled (grappled), use Rigidbody physics
        if (!characterController.enabled)
        {
            return; // Don't apply any manual movement
        }

        if (!ignoreGrounding)
        {
            velocity.y += gravity * dt;
        }
        else
        {
            velocity.y = 0f;
        }

        // Apply horizontal velocity (momentum) as well
        Vector3 motion = Vector3.right * (horizontalVelocity + velocity.x) * dt + Vector3.up * velocity.y * dt;
        characterController.Move(motion);

        // Gradually reduce cached horizontal velocity (simulate friction/air resistance)
        velocity.x *= 0.98f;

        bool isGroundedNow = characterController.isGrounded;

        if (!ignoreGrounding)
        {
            if (wasGrounded && !isGroundedNow)
            {
                OnBecameAirborne();
            }

            if (isGroundedNow && velocity.y < 0f)
            {
                velocity.y = -2f;
            }
        }

        wasGrounded = isGroundedNow;
    }

    public void SetIgnoreGrounding(bool value, Vector3 velocityToApply = default)
    {
        ignoreGrounding = value;
        
        if (characterController)
        {
            if (value)
            {
                // Disabling CharacterController (grappling)
                characterController.enabled = false;
            }
            else
            {
                // Re-enabling CharacterController (un-grappling)
                characterController.enabled = true;
                
                // Apply cached velocity
                if (velocityToApply != default)
                {
                    velocity = velocityToApply;
                }
            }
        }
    }

    void OnBecameAirborne()
    {
        Debug.Log("Runner has become airborne!");
    }

    IEnumerator MoveLegs()
    {
        while (true)
        {
            // move left leg forward and right leg backward, Z axis
            legLeft.transform.localRotation = Quaternion.Euler(0, 0, 20);
            legRight.transform.localRotation = Quaternion.Euler(0, 0, -20);

            // wait for a short interval
            yield return new WaitForSeconds(legMoveInterval);

            // move left leg backward and right leg forward
            legLeft.transform.localRotation = Quaternion.Euler(0, 0, -20);
            legRight.transform.localRotation = Quaternion.Euler(0, 0, 20);

            // wait for a short interval
            yield return new WaitForSeconds(legMoveInterval);
        }
    }
}
