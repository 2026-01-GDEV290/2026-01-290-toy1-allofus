using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementHunt : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;

    public float airMult;

    bool canJump;

    float jumpTimer = 0.15f;

    [Header("Input")]
    public KeyCode jumpKey = KeyCode.Space;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    bool grounded;

    public Transform orientaition;

    float horizontal;
    float vertical;

    Vector3 moveDir;

    Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        canJump = true;
    }

    private void Update()
    {

        //Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * .5f + .2f, ground);

        Debug.DrawRay(transform.position, Vector3.down, Color.darkBlue);

        MyInput();

        SpeedControl();

        //handle drag

        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(jumpKey))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
            StartCoroutine(resetJump());
        }
    }

    IEnumerator resetJump()
    {
        yield return new WaitForSeconds(jumpTimer);
        canJump = true;
    }

    private void MovePlayer()
    {
        moveDir = orientaition.forward * vertical + orientaition.right * horizontal;

        if (grounded)
            rb.AddForce(moveDir * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDir * moveSpeed * 10f * airMult, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limVel.x, rb.linearVelocity.y, limVel.z);
        }
    }
}
