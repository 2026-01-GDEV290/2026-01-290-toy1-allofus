using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    // Drag and drop the GameObject you want to activate into this field in the Inspector
    public GameObject objectToActivate;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Activate the target GameObject
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
                Debug.Log("Player entered trigger. Object activated.");
            }
        }
    }

    // Optional: Use OnTriggerExit to deactivate the object when the player leaves the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(false);
                Debug.Log("Player exited trigger. Object deactivated.");
            }
        }
    }
}
