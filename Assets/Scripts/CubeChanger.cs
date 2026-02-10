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

    public float scaleFactor;

    public AudioSource rattle;

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
            this.transform.localScale -= new Vector3(scaleFactor, scaleFactor, scaleFactor);
            rb.mass = newMass;
            leftScaleCollider.weight = newMass;
            rattle.Play();
            //Debug.Log("Accessed Scale Weight: " + leftScaleCollider.TotalWeight);
        }
        else
        {
            this.GetComponent<Renderer>().material = red;
            this.transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
            rb.mass = originalMass;
            leftScaleCollider.weight = originalMass;
            rattle.Play();
        }
    }
}
