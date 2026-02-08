using UnityEngine;

public class deleteAfter : MonoBehaviour
{
    AudioSource source;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.tag.Equals("Box"))
        {
            source.volume = rb.linearVelocity.magnitude;
            source.volume = collision.relativeVelocity.magnitude/50;
            source.pitch = Random.Range(1.5f, 2f);
            source.Play();
        }
    }
    void Update()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
