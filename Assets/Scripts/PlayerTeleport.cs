using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gameObject.transform.position = new Vector3(237f, 74f, 300f);
        }
    }
}
