using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float senY;

    float aimSensX;
    float aimSensY;

    float currentAimX;
    float currentAimY;

    public Transform playerRotation;

    float xRotation;
    float yRotation;

    [SerializeField]
    GameObject CrossHair;

    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        aimSensX = sensX / 2;
        aimSensY = senY / 2;
    }

    public void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * currentAimX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * currentAimY;

        yRotation += mouseX;

        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation,0);
        playerRotation.rotation = Quaternion.Euler(0, yRotation, 0);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            cam.fieldOfView = 8;
            CrossHair.SetActive(true);

            currentAimX = aimSensX;
            currentAimY = aimSensY;
        }
        else
        {
            CrossHair.SetActive(false);
            cam.fieldOfView = 60;

            currentAimX = sensX;
            currentAimY = senY;
        }
    }
}
