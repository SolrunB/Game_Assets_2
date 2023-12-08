using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float initialHealth = 100f;
    public float decreaseRate = 1f; //health decrease rate per second
    public HealthBar healthBar;

    private float currentHealth;

    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = initialHealth;
        healthBar.SetMaxHealth(initialHealth);
        StartCoroutine(DecreaseHealthOverTime());
       

    }

    IEnumerator DecreaseHealthOverTime()
    {
        while (currentHealth > 0f)
        {
            yield return new WaitForSeconds(1f); //decrease health over time 
            currentHealth -= decreaseRate;
            healthBar.SetHealth(currentHealth); 
            //Debug.Log("Current health: " + currentHealth); 

            if (currentHealth <= 0f)
            {
                currentHealth = 0f;
                healthBar.SetHealth(currentHealth);
                Debug.Log("Out of health!"); 
            }
        }
    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount; 

        if (currentHealth > initialHealth)
        {
            currentHealth = initialHealth; 
        }

        healthBar.SetHealth(currentHealth);
        Debug.Log("Health Restored by: " + amount + ". Current health; " + currentHealth); 
    }

   
}
