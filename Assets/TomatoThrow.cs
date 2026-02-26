using UnityEngine;

public class TomatoThrow : MonoBehaviour
{
    [SerializeField]
    GameObject tomato;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 pos = new Vector2(Random.Range(-8,8),Random.Range(-6,6));
            Instantiate(tomato,pos,Quaternion.identity);
        }
    }
}
