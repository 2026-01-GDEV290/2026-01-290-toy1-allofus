using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] FlashImage flashImage = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flashImage.StartFlash(.25f, .8f, Color.white);
        }
    }
}
