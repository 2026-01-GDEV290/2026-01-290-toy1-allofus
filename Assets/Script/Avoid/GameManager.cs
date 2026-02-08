using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Vector3 spawnVector;
    [SerializeField]
    GameObject Disc;

    [SerializeField]
    float timeBetween;
    float timer;

    private void Start()
    {
        Time.timeScale = 1;
        timer = timeBetween;
        spawnVector = new Vector3(0,14,0.54f);
    }
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            spawnVector.x = Random.Range(-7.5f, 7.5f);

            timer = timeBetween;
            GameObject gameOBJ = Instantiate(Disc, spawnVector ,Disc.transform.rotation);
        }
    }

    public void RestartToy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
