using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class ActivationObject : MonoBehaviour
{
    public UnityEvent OnActivation = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            OnActivation.Invoke(); 
        }
    }

}
