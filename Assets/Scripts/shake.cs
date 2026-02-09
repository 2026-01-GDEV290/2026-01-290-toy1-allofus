using UnityEngine;

public class shake : MonoBehaviour
{
    public Animator screenShake;


    void Start()
    {
        Debug.Log("Shake Script is being read");
        screenShake = GetComponent<Animator>();

        screenShake.SetBool("shake", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            if(screenShake.GetBool("shake") == false)
            {
                Debug.Log("Input! Yes!");
                screenShake.SetBool("shake", true);

     
            }
            else if (screenShake.GetBool("shake") == true)
            {
                screenShake.SetBool("shake", false);
                Debug.Log("Else statement read");
            }
        }

    }

    /*public void OnMouseDown()
    {
        
        //screenShake.SetBool("shake", true);
        //screenShake.SetBool("shake", false);
    }*/

    public void OnMouseDown()
    {
        Debug.Log("Input! Yes!");
    }
}
