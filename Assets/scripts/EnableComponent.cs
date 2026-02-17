using Unity.VisualScripting;
using UnityEngine;

public class EnableComponent : MonoBehaviour
{
    private Animator myAnimator;
    private AudioSource myAudio;
    public GameObject Zzz;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myAnimator.enabled = !myAnimator.enabled;
            myAudio.enabled = !myAudio.enabled;
        }
        if (myAudio.enabled == true)
        {
            Zzz.SetActive(true);
        }
        if (myAudio.enabled == false)
        {
            Zzz.SetActive(false);
        }
    }
}
