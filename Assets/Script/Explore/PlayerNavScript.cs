using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using Unity.Cinemachine;
using UnityEngine.UIElements;
public class PlayerNavScript : MonoBehaviour
{
    Vector3 target;

    NavMeshAgent agent;
    
    [SerializeField]
    GameObject shower; // giggity
    [SerializeField]
    Material showerMat;

    [SerializeField]
    CinemachineInputAxisController cinemachineInputAxisController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shower.SetActive(false);
        target = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked();
        }
        if (Vector3.Distance(transform.position,target) <= 2)
        {
            shower.SetActive (false);
        }
        if (shower.activeInHierarchy)
        {
            showerMat.color = new Color(showerMat.color.r, showerMat.color.g, showerMat.color.b, Mathf.Clamp(Vector3.Distance(transform.position, target) / 20, 0, 1));
        }

        if (Input.GetMouseButtonDown(1))
        {
            cinemachineInputAxisController.enabled = true;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }
        if(Input.GetMouseButtonUp(1))
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            cinemachineInputAxisController.enabled = false;
        }
    }

    void clicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 localHit = hit.point;
            agent.destination = localHit;
            target = agent.destination;
            showerMat.color = new Color(showerMat.color.r,showerMat.color.g,showerMat.color.b,1);
            shower.transform.position = localHit;
            shower.SetActive(true);
        }
    }
}
