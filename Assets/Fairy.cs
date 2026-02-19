using UnityEngine;

public class Fairy : MonoBehaviour
{
    public AudioSource fairySfx;
    public ParticleSystem fairyLights;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fairySfx = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "GameController"){
            fairySfx.Play();
            ParticleSystem effect = Instantiate(fairyLights);
            fairyLights.Play();

        }

    }
}
