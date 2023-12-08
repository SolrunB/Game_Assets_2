using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform playerController;
    bool inside = false;
    public float speed = 3f;
    public FP_Controller player;

    void Start()
    {
        player = GetComponent<FP_Controller>();
        inside = false;
    }


    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Ladder")
        {
            Debug.Log("TouchingLadderTrue");
            player.enabled = false;
            inside = !inside;
        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "Ladder")
        {
            Debug.Log("TouchingLadderFalse");
            player.enabled = true;
            inside = !inside;
        }
    }

    void Update()
    {
        if (inside == true && Input.GetKey("w"))
        {
            player.transform.position += Vector3.up /
            speed * Time.deltaTime;
        }

        if (inside == true && Input.GetKey("s"))
        {
            player.transform.position += Vector3.down /
            speed * Time.deltaTime;
        }

    }

}
