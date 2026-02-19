using UnityEngine;
using Unity.Cinemachine;
public class PlayerFocus : MonoBehaviour
{
    [SerializeField]
    CinemachineTargetGroup targetGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    CinemachineTargetGroup JustPlayerTargetGroup;

    [SerializeField]
    GameObject[] attackable;
    [SerializeField]
    Camera cam;

    [SerializeField]
    GameObject FocusShower;

    public float Range;

    [SerializeField]
    GameObject Closest;
    bool focused;
    void Start()
    {
        JustPlayerTargetGroup = new CinemachineTargetGroup();

        JustPlayerTargetGroup.AddMember(transform,1f,1f);

        targetGroup.Targets = JustPlayerTargetGroup.Targets;

        focused = false;

        attackable = GameObject.FindGameObjectsWithTag("Attackable");

        FocusShower.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !focused)
        {
            lockOn();
            focused = true;
        }
        if(focused && !Input.GetKey(KeyCode.LeftShift))
        {
            targetGroup.Targets.Clear();
            targetGroup.AddMember(transform, 1, 1);
            focused = false;
            FocusShower.SetActive(false);
        }

        if (focused && Closest != null)
        {
            transform.LookAt(new Vector3(Closest.transform.position.x,transform.position.y,Closest.transform.position.z));
            cam.transform.LookAt(Closest.transform.position);
            FocusShower.SetActive(true);
            FocusShower.transform.position = new Vector3(Closest.transform.position.x, (Closest.transform.position.y + 1f), Closest.transform.position.z);
        }
    }

    void lockOn()
    {
        foreach (GameObject i in attackable)
        {
            Vector3 screenPos = cam.WorldToScreenPoint(i.transform.position);
            bool onScreen = screenPos.x > 0f && screenPos.x < UnityEngine.Screen.width && screenPos.y > 0f && screenPos.y < UnityEngine.Screen.height;

            float itteration = Vector3.Dot(cam.transform.forward, (i.transform.position - cam.transform.position).normalized);

            if (Closest != null)
            {

                if (Closest != i)
                {
                    if (itteration > Vector3.Dot(cam.transform.forward, (Closest.transform.position - cam.transform.position).normalized) && itteration > .90f && Vector3.Distance(i.transform.position, gameObject.transform.position) < Range)
                    {
                        Closest = i;
                    }
                    else if (Vector3.Dot(cam.transform.forward, (Closest.transform.position - cam.transform.position).normalized) < .90f || Vector3.Distance(Closest.transform.position, gameObject.transform.position) > Range)
                    {
                        Closest = null;
                    }
                }
            }
            else if (itteration > .90f && Vector3.Distance(i.transform.position, gameObject.transform.position) < Range)
            {
                Closest = i;
            }

        }
        if (Closest != null)
        {
            targetGroup.AddMember(Closest.transform, 0.25f, .25f);
        }
    }
}
