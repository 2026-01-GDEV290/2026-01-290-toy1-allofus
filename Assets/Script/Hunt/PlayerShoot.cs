using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    AudioSource gunShotSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("shooting");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        gunShotSFX.Play();

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit,float.PositiveInfinity))
        {
            Debug.Log("ray at: " + hit.point);
            if (!hit.IsUnityNull())
            {
                if (hit.transform.gameObject != null)
                {
                    Debug.Log("trying for animalScript");
                    AnimalScript animal = hit.transform.gameObject.GetComponent<AnimalScript>();
                    if (animal != null)
                    {
                        animal.kill();
                    }
                }

            }
        }
    }
}
