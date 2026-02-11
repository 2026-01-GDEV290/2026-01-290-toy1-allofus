using UnityEngine;
using UnityEngine.SceneManagement;

public class ToyManager : MonoBehaviour
{ 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
