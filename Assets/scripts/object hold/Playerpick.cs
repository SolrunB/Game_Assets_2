using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerpick : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    [SerializeField]
    private Transform pickUpPoint;

    [SerializeField]
    private GameObject inHandItem;

    private RaycastHit hit;
    private Rigidbody rb;

    private void Start()
    {
        CheckForKeyInput();
    }

    private void Update()
    {
        CheckForKeyInput();

        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);

        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
        }

        if (inHandItem != null)
        {
            return;
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
        }
    }

    private void CheckForKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformPickUpAction();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            PerformDropAction();
        }
    }

    private void PerformPickUpAction()
    {
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Rigidbody itemRigidbody = hit.collider.GetComponent<Rigidbody>();

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.GetComponent<Item>())
                {
                    Debug.Log("its picked up");
                    inHandItem = hit.collider.gameObject;
                    inHandItem.transform.SetParent(pickUpPoint.transform, true);
                    if (itemRigidbody != null)
                    {
                        itemRigidbody.isKinematic = true;
                    }
                    return;
                }
            }
        }
    }

    private void PerformDropAction()
    {
        if (inHandItem != null)
        {
            Debug.Log("item dropped");
            // Set the pickableLayerMask to include all layers for detection
            pickableLayerMask = int.MaxValue;
            Rigidbody itemRigidbody = inHandItem.GetComponent<Rigidbody>();

            if (itemRigidbody != null)
            {
                itemRigidbody.isKinematic = false;
            }

            inHandItem.transform.parent = null;
            inHandItem = null;
        }
    }
}