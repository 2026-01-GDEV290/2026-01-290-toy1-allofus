using UnityEngine;

public class StringCollided : MonoBehaviour
{
    // public delegate when string collider is hit
    public delegate void StringHitHandler(Collider runner);
    public event StringHitHandler OnStringHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "Runner"
        if (other.gameObject.CompareTag("Runner"))
        {
            Debug.Log("String hit by Runner!"); // Log the collision for debugging purposes
            // Invoke the event to notify subscribers that the string was hit
            OnStringHit?.Invoke(other);
        }
    }
}
