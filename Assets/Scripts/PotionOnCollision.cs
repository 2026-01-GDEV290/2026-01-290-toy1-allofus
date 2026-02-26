using UnityEngine;

public class PotionOnCollision : MonoBehaviour
{
    private void DestroyOnCollision(Collision2D collision){

        if (collision.gameObject.CompareTag("Red") || collision.gameObject.CompareTag("Yellow") || collision.gameObject.CompareTag("Blue"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

    private void ColorMixer(){

        /* Not complete, sorry */

    }
}
