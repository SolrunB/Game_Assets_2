using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestoreObject : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float healthToRestore = 20f;
    public GameObject openText;
    public HealthBar health; 
    
    private bool isInRange = false;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            openText.SetActive(true); 
        }
        else
        {
            openText.SetActive(false); 
        }

        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            RestoreHealth(); 
        }
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player in zone");
            isInRange = true; 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RestoreHealth(); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player left zone");
            isInRange = false; 
        }
    }


    void RestoreHealth()
    {
        playerHealth.RestoreHealth(healthToRestore); 
         
       
    }
}
