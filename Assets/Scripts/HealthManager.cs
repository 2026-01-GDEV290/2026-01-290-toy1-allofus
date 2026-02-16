using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 20f;

    public AudioSource healthSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(20f);
        }
    }

    public void Heal(float healingAmount)
    {
        healthSFX.Play();
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100f);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
