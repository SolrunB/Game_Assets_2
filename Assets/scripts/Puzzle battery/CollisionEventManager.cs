using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollisionEventManager : MonoBehaviour
{
    public UnityEvent onCollisionEnterEvent = new UnityEvent();

    private void OnCollisionEnter(Collision collision)
    {
        onCollisionEnterEvent.Invoke(); 
    }

}
