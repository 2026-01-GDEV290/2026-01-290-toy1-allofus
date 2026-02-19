using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject throwObj;
    public int spawnLimit;
    private int spawnCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && spawnCount < spawnLimit)
        {
            Instantiate(throwObj, transform.position, Quaternion.identity);
            spawnCount++;
        }
    }

    private void DestroyThrowObject()
    {
        DestroyImmediate(throwObj, true);
    }
}
