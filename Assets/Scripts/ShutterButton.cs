using UnityEngine;

public class ShutterButton : MonoBehaviour
{
    public Animator button;
    public AudioSource click;

    [SerializeField] FlashImage flashImage = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (button.GetBool("wasPushed") == false)
            {
                Debug.Log("Input! Yes!");
                button.SetBool("wasPushed", true);
                click.Play();
                flashImage.StartFlash(.25f, .8f, Color.white);


            }
            else if (button.GetBool("wasPushed") == true)
            {
                button.SetBool("wasPushed", false);
                Debug.Log("Else statement read");
            }
        }
    }

    /*public void OnMouseDown()
    {
        button.SetBool("wasPushed", true);
    }*/
}
