using UnityEngine;

public class PointToMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.LookAt(new Vector3(mousePos.x,mousePos.y,transform.position.z));
    }
}
