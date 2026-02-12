using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform destination;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            player.transform.position = destination.transform.position;
            //makes one position = another
        }
    }
}
