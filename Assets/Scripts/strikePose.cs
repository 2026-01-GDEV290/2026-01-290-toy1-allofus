using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class strikePose : MonoBehaviour
{

    public Animator pose;
    //public bool dance1 = false;


    private AudioSource source;

    public AudioClip[] sounds;

    string[] animations = {"dance1", "stand2", "run1", "dance2", "run2", "stand1"};
    int chosenAnim = 0;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            if(chosenAnim < animations.Length - 1)
            {
                chosenAnim++;
            }
            else
            {
                chosenAnim = 0;
            }

            pose.SetBool(animations[chosenAnim], true);
            source.clip = sounds[chosenAnim];
            source.Play();

        }
        else
        {
            pose.SetBool(animations[chosenAnim], false);
        }
    }

    /*public void OnMouseDown()
    {
        pose.SetBool("shake", true);
    }*/

}
