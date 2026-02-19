using UnityEngine;

public class Teleport : MonoBehaviour, IInteractable
{
    public GameObject player;
    public Transform destination;
    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
                player.transform.position = destination.transform.position;
                //makes one position = another
            }
        return true;
    }
        
    }

