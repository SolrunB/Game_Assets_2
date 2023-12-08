using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TextPopUp : MonoBehaviour
{
    public GameObject UIobject; 
    // Start is called before the first frame update
    void Start()
    {
        UIobject.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIobject.SetActive(true);
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        UIobject.SetActive(false); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
