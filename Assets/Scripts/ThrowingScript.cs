using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class ThrowingScript : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject throwObject;

    [Header("Throwing Logic")]
    public float throwForce;
    public float throwUpwardForce;
    public bool ready2throw;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    public InputActionAsset inputActions;
    private InputAction throwButton;

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
        throwButton = InputSystem.actions.FindAction("Attack");
    }

    private void Throw()
    {
        ready2throw = true;

        //instantiate object to throw
        GameObject projectile = Instantiate(throwObject, attackPoint.position, cam.rotation);

        //get rigidbody
        Rigidbody projectilerb = projectile.GetComponent<Rigidbody>();

        //add force
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectilerb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        //remove thrown game object
        throwObject = null;

        //throw cooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        ready2throw = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ready2throw = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (throwButton.WasPressedThisFrame() && ready2throw && totalThrows > 0)
        {
            Throw();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Throwable")
        {
            throwObject = collision.gameObject;
        }
    }
}
