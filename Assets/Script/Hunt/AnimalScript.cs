using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AnimalScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    NavMeshAgent agent;

    [SerializeField]
    float walkDistance;

    float standTime;

    bool waitingToMove;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Reposition();
        transform.position = agent.destination;
        Reposition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(agent.destination, agent.transform.position) < 5 && !waitingToMove)
        {
            waitingToMove = true;
            StartCoroutine(waitForNewDestination(Random.Range(5, 25)));
        }
    }

    void Reposition()
    {
        Vector3 randomDir = UnityEngine.Random.insideUnitSphere * walkDistance;

        randomDir += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDir, out hit, walkDistance, 3);
        Vector3 finalPos = hit.position;

        agent.destination = finalPos;
    }

    public void kill()
    {
        Destroy(gameObject);
    }

    IEnumerator waitForNewDestination(float timer)
    {
        yield return new WaitForSeconds(timer);
        Reposition();
        waitingToMove = false;
    }
}
