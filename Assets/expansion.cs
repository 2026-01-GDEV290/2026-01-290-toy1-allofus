using UnityEngine;

public class HoldToExpand : MonoBehaviour
{
    public float expandSpeed = 2f;

    private Vector3 originalScale;

    void Start()
    {
        // Store the starting size
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Expand while holding E
        if (Input.GetKey(KeyCode.E))
        {
            transform.localScale += Vector3.one * expandSpeed * Time.deltaTime;
        }

        // Reset size when pressing R
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.localScale = originalScale;
        }
    }
}
