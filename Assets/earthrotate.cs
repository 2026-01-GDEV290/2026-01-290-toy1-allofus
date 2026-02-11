using UnityEngine;

public class SimpleSphereRotate : MonoBehaviour
{
    public float rotationSpeed = 20f; // increased from 5 to 20 for bigger rotation
    private Vector3 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotationY = delta.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationY, 0, Space.World);
            lastMousePosition = Input.mousePosition;
        }
    }
}
