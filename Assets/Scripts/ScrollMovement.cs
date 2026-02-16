using UnityEngine;

public class ScrollMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed =100f;
    public float yPos = 1.76f; 
    void Start()
    {
        yPos = 24.76f;
        speed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        //going up
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            //speed += 0.25f;
            yPos += 1f;
            if (yPos > 24.76f)
            {
                yPos = 24.76f;
            }

            transform.Translate(Vector3.up * speed * Time.deltaTime);
            //transform.position += new Vector3(0, yPos, 0) * speed * Time.deltaTime;
        }
        //going down
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            //speed -= 0.25f;
            yPos -= 1f;
            if(yPos < 2.76f)
            {
                yPos = 2.76f;
            }
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            //transform.position += new Vector3(0, yPos, 0) * speed * Time.deltaTime;
        }
        //transform.position += new Vector3(0, yPos, 0);
        //transform.Translate(Vector3.down * speed* Time.deltaTime);
    }
}
