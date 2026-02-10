using UnityEngine;

public class NewFollow : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    public AudioClip getSound;
    public float volume = 1.0f;

    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AudioSource.PlayClipAtPoint(getSound, transform.position, volume);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
