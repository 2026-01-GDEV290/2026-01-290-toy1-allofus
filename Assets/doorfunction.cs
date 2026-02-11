using UnityEngine;

public class doorsnap : MonoBehaviour
{
    private Transform door;        // main door model
    private Transform dooropen;    // child marker "dooropen"
    private Transform doorclosed;  // child marker "doorclosed"

    void Start()
    {
        door = transform;

        dooropen = transform.Find("dooropen");
        doorclosed = transform.Find("doorclosed");

        if (doorclosed != null)
        {
            door.position = doorclosed.position;
            door.rotation = doorclosed.rotation;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dooropen != null)
        {
            door.position = dooropen.position;
            door.rotation = dooropen.rotation;
        }

        if (Input.GetKeyDown(KeyCode.W) && doorclosed != null)
        {
            door.position = doorclosed.position;
            door.rotation = doorclosed.rotation;
        }
    }
}
