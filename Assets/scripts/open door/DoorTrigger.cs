using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;
    public GameObject Key; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Debug.Log("collision with key"); 
            OpenDoor(); 
        }
    }

    void OpenDoor()
    {
        doorAnimator.SetBool("Open", true); // Trigger the "Open" animation
        Debug.Log("opening door"); 
    }
}
