using UnityEngine;

public class BaloonThemToy : MonoBehaviour
{
    Camera cam;
    [SerializeField] GameObject runnerPrefab;
    [SerializeField] GameObject balloonPrefab;
    [SerializeField] Vector3 spawnPoint;
    [SerializeField] Vector3 balloonSpawnPoint;

    void Awake()
    {
        cam = Camera.main;
        // spawn runner every x seconds
        InvokeRepeating("SpawnRunner", 1f, 4f);
        Invoke("SpawnBalloon", 1f);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // if S key pressed, switch scene
        if (Input.GetKeyDown(KeyCode.S))
        {
            // switch scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("Toy01");
        }
        
    }
    void SpawnRunner()
    {
        if (runnerPrefab)
        {
            Instantiate(runnerPrefab, spawnPoint, Quaternion.identity);
        }
    }
    public void SpawnBalloon()
    {
        if (balloonPrefab)
        {
            Instantiate(balloonPrefab, balloonSpawnPoint, Quaternion.identity);
        }
    }
}
