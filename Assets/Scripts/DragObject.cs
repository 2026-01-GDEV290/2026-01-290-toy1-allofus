using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    //public GameObject health;
    private HealthManager healthManager;

    void Start()
    {
        //health = GetComponent<HealthManager>();
        GameObject health = GameObject.Find("HealthManager");
        if(health != null)
        {
            healthManager = health.GetComponent<HealthManager>();
        }
        else
        {
            Debug.Log("Initial health manager detection is null.");
        }
    }
    public void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(

        gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen

        mousePoint.z = mZCoord;

        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Character"))
        {
            Destroy(this.gameObject);
            Debug.Log("Collider Detected");

            if (healthManager != null)
            {
                //health = 
                healthManager.Heal(20f);
            }
            else
            {
                Debug.Log("Health could not be detected.");
            }
            
        }
    }
}
