using Unity.VisualScripting;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    NewFollow col;

    void Start()
    {
        col = GetComponent<NewFollow>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            col.enabled = true;
        }
    }
}