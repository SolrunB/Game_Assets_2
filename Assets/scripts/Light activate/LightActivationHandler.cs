using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightActivationHandler : MonoBehaviour
{
    public LightColTrigger lightColTrigger1;
    public LightColTrigger lightColTrigger2;
    public LightColTrigger lightColTrigger3;
    public Light targetLightToTurnOff;
    public Light targetLightToActivate;

    public event Action LightsActivatedEvent; // Custom event for triggering light changes

    void Start()
    {
        lightColTrigger1.LightActivated += CheckLightsActivated;
        lightColTrigger2.LightActivated += CheckLightsActivated;
        lightColTrigger3.LightActivated += CheckLightsActivated;
        targetLightToActivate.GetComponent<Light>().enabled = false;
    }

    void CheckLightsActivated()
    {
        if (lightColTrigger1.lightActivated && lightColTrigger2.lightActivated && lightColTrigger3.lightActivated)
        {
            // Trigger the custom event when all three lights are activated
            OnLightsActivatedEvent();
        }
    }

    void OnLightsActivatedEvent()
    {
        Debug.Log("Three specific lights activated!");

        // Turn off the target light and activate another
        if (targetLightToTurnOff != null)
        {
            targetLightToTurnOff.enabled = false;
        }

        if (targetLightToActivate != null)
        {
            targetLightToActivate.enabled = true;
            targetLightToActivate.GetComponent<Light>().enabled = true;
        }

        // Trigger the event for external subscriptions
        LightsActivatedEvent?.Invoke();
    }

    void OnDestroy()
    {
        lightColTrigger1.LightActivated -= CheckLightsActivated;
        lightColTrigger2.LightActivated -= CheckLightsActivated;
        lightColTrigger3.LightActivated -= CheckLightsActivated;
    }
}
