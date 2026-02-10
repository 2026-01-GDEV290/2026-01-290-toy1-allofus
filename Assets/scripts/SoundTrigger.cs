using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
        
    public AudioSource audioSource; // Assign in Inspector
    public AudioClip enterSound;
    public AudioClip exitSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enterSound != null) audioSource.PlayOneShot(enterSound);
            else audioSource.Play(); // Plays default clip
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (exitSound != null) audioSource.PlayOneShot(exitSound);
            else audioSource.Stop();
        }
    }
}