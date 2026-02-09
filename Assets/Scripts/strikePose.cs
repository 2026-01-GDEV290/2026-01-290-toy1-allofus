using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class strikePose : MonoBehaviour
{

    public Animator pose;
    public bool dance1 = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Input has been read.");
        }
    }

    /*void OnMouseDown()
    {
        Debug.Log("Input has been read.");
    }*/
}
