using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSpin : MonoBehaviour
{
    public float speed = 0;
  
    void Update ()
    {
        
       transform.Rotate(Vector3.up, speed);
       if (Input.GetMouseButtonDown(0))
       speed += 1f;
       if 
    }

}


