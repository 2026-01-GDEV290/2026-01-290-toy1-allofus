using UnityEngine;

public class FollowPlayer : MonoBehaviour

{
    [SerializeField] public float speed = 1.5f;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
        void OnTriggerEnter(Collider other)
        {
            // Check if the object entering the trigger has the "Player" tag
            if (other.CompareTag("Player"))
            {
                player = GameObject.FindGameObjectWithTag("Player");

                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    void OnTriggerExit(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player");

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
