using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class strikePose : MonoBehaviour
{

    public Animator pose;
    //public bool dance1 = false;

    string[] animations = { "dance1", "run1", "run2", "stand1" };
    int chosenAnim = 0;

    private void Start()
    {

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
            //pose.SetBool("shake", true);
        }
        else
        {
            pose.SetBool(animations[chosenAnim], false);
            //pose.SetBool("shake", false);
        }
    }

    /*public void OnMouseDown()
    {
        pose.SetBool("shake", true);
    }*/

}
