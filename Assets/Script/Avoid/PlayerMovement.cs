using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float bounds;

    [SerializeField]
    GameObject gameOverScreen;

    Vector3 Mult;
    void Start()
    {
        //Mult = new Vector3(1,transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Disc")
        {
            gameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if ((transform.position.x > -bounds && horizontal < 0) || (transform.position.x < bounds && horizontal > 0))
        {
            transform.position += Vector3.right * horizontal * speed * Time.deltaTime;
        }
    }

    void gameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
