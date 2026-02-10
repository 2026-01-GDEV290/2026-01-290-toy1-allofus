using JusticeScale.Scripts.Scales;
using UnityEngine;

public class CubeChanger : MonoBehaviour
{

    public Material red;
    public Material blue;

    private bool isRed;
    //private bool isBlue;

    private Rigidbody rb;

    public float newMass = 10f;
    public float originalMass = 20f;

    public GameObject leftScale;
    private TriggerScale leftScaleCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        leftScaleCollider = leftScale.GetComponent<TriggerScale>();
        if(leftScaleCollider != null)
        {
            Debug.Log("Successfully accessed LeftCollider");
        }
    }
    public void OnMouseDown()
    {
        isRed = !isRed;
        if(isRed)
        {
            this.GetComponent<Renderer>().material = blue;
            rb.mass = newMass;
            leftScaleCollider.weight = newMass;
            //Debug.Log("Accessed Scale Weight: " + leftScaleCollider.TotalWeight);
        }
        else
        {
            this.GetComponent<Renderer>().material = red;
            rb.mass = originalMass;
            leftScaleCollider.weight = originalMass;
        }
    }
}
