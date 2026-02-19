using UnityEngine;

public class VerticalOnlyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            move = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move = -moveSpeed;
        }

        transform.Translate(0f, move * Time.deltaTime, 0f);
    }
}
