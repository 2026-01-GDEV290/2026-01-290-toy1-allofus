using UnityEngine;

public class GrappleThemToy : MonoBehaviour
{
    Camera cam;
    [SerializeField] GameObject runnerPrefab;
    [SerializeField] Vector3 spawnPoint;

    void Awake()
    {
        cam = Camera.main;
        // spawn runner every x seconds
        InvokeRepeating("SpawnRunner", 1f, 4f);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRunner()
    {
        if (runnerPrefab)
        {
            Instantiate(runnerPrefab, spawnPoint, Quaternion.identity);
        }
    }

}
