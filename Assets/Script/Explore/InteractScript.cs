using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    MeshRenderer meshRenderer;

    Color startcolor;

    bool isHovered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        startcolor = meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        Physics.Raycast(ray, out hit);

        if (MouseScreenCheck() == true)
        {
            if (!hit.IsUnityNull())
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject != null)
                    {
                        if (hit.collider.gameObject == gameObject)
                        {
                            isHovered = true;
                            meshRenderer.material.color = Color.limeGreen;
                        }
                        else
                        {
                            isHovered = false;
                            meshRenderer.material.color = startcolor;
                        }

                        if (Input.GetMouseButtonDown(0) && isHovered)
                        {
                            interact();
                        }
                    }
                }
            }
        }else
        {
            isHovered = false;
            meshRenderer.material.color = startcolor;
            hit = new RaycastHit();
        }
    }

    void interact()
    {
        Debug.Log("this is a " + gameObject.name);
    }
    //checks if the mouse is on screen returns false if not and true if it is
    //Written by user: raoz on the unity forums https://discussions.unity.com/t/best-way-to-highlight-an-object-on-mouse-over/38994
    public bool MouseScreenCheck()
    {
#if UNITY_EDITOR
        if (Input.mousePosition.x == 0 || Input.mousePosition.y == 0 || Input.mousePosition.x >= Handles.GetMainGameViewSize().x - 1 || Input.mousePosition.y >= Handles.GetMainGameViewSize().y - 1)
        {
            return false;
        }
#else
        if (Input.mousePosition.x == 0 || Input.mousePosition.y == 0 || Input.mousePosition.x >= Screen.width - 1 || Input.mousePosition.y >= Screen.height - 1) {
        return false;
        }
#endif
        else
        {
            return true;
        }
    }
}
