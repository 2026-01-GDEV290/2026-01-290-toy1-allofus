using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
  
    public int Respawn;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(Respawn);
        }
    }
}

