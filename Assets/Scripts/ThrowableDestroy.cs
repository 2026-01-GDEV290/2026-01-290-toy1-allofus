using UnityEngine;

public class ThrowableDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(DestroyThrowable), 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyThrowable()
    {
        Destroy(this.gameObject);
    }
}
