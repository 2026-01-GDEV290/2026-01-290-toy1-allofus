using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public InputActionAsset inputActions;
    public float speed;

    private Rigidbody rb;
    private InputAction moveInput;
    private InputAction jumpInput;
    private InputAction lookInput;

    public float jumpSpeed = 5.0f;
    public float baseMoveSpeed = 4f;
    public float accelerationRate = 0.55f;
    public float lookSpeed = 10.0f;
    public float rotateSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        moveInput = InputSystem.actions.FindAction("Move");
        jumpInput = InputSystem.actions.FindAction("Jump");
        lookInput = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 movement = moveInput.ReadValue<Vector2>();
        Vector2 lookAmnt = lookInput.ReadValue<Vector2>();

        if (jumpInput.WasPressedThisFrame())
        {
            rb.AddForceAtPosition(new Vector3 (0, jumpSpeed, 0), Vector3.up, ForceMode.Impulse);
        }

        rb.AddForce(movement.x/2, 0, movement.y, ForceMode.Acceleration);
    }

    private void FixedUpdate()
    {
        
    }

    
}
