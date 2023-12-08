using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class LightColTrigger : MonoBehaviour
{
    public GameObject targetObject;
    public Light activationLight;
    public event Action LightActivated; 

    private int PickableLayer;

    public bool lightActivated = false;
    
    private bool isStuck = false;
    private bool isPickedUp = false;
    private Item itemScript;
    

    private Rigidbody rb;
    private Collider coll; 


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>(); 
        PickableLayer = LayerMask.NameToLayer("Pickable");
        activationLight.GetComponent<Light>().enabled = false;

        itemScript = GetComponent<Item>(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!isStuck && collision.gameObject == targetObject)
        {
            isStuck = true;

            transform.parent = collision.transform;

             
            if(rb != null)
            {
                rb.isKinematic = true; 
            }
            coll.enabled = false; 

            gameObject.layer = 0;
            
            if(itemScript != null)
            {
                itemScript.enabled = false; 
            }
            isPickedUp = true; 

            if(activationLight != null)
            {
                activationLight.enabled = true; 
            }

            if (!lightActivated)
            {
                lightActivated = true; 
                OnLightsActivated(); 
            }
        }
    }

    private void OnEnable()
    {
        if (isPickedUp)
        {
            coll.enabled = true; 
        }
    }

    private void FixedUpdate()
    {
        if(!isStuck && rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero; 
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isStuck && collision.gameObject != targetObject)
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    void OnLightsActivated()
    {
        Debug.Log("3 lights activated");
        LightActivated?.Invoke(); 
    }


   
}
