using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator doorAnimator;
    public GameObject key;

    public LayerMask interactableMask;
    public float interactionRange = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray interactionRay = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(interactionRay, out hit, interactionRange, interactableMask))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    if (key.activeSelf) // Assuming the key is a GameObject that can be activated/deactivated
                    {
                        doorAnimator.SetBool("Open", true);
                    }
                    else
                    {
                        // The door remains locked or handle the locked door behavior here
                    }
                }
            }
        }
    }
}
