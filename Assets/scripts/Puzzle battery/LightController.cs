using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light activationLight;

    private void Start()
    {
        // Get the ActivationObject from a GameObject in the scene
        ActivationObject activationObject = FindObjectOfType<ActivationObject>();

        // Subscribe to the activation event
        if (activationObject != null)
        {
            activationObject.OnActivation.AddListener(ActivateLight);
        }

    }
    
    
    public void ActivateLight()
    {
        if (activationLight != null)
        {
            activationLight.enabled = true; 
        }
    }
     
}
