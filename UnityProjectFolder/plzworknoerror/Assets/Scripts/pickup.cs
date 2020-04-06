using System;
using System.Collections;
using UnityEngine;

public class pickup : MonoBehaviour
{
    int layermask = 1 << 10;
    public Camera FPScamera;
    public RaycastHit hit;
    public float pickuprange;
    public LayerMask pickupableobjects;
    public float pickupspeed;
    public Transform Pickupdestination;
    public bool somethinginhand;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && somethinginhand == false)
        {
            if (Physics.Raycast(FPScamera.transform.position, FPScamera.transform.forward, out hit, pickuprange, layermask))
            {
                somethinginhand = true;
                target = hit.collider.transform.gameObject;
                target.Rigidbody.useGravity = false;
                target.transform.SetParent(transform FPScamera);

                /*
                Rigidbody body = hit.collider.GetComponent<Rigidbody>();
                body.useGravity = false;
                body.transform.position = Pickupdestination.position; 
                */
            }
        }

        if (somethinginhand == true && Input.GetKeyDown(KeyCode.E))
        {

            somethinginhand = false;
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }








    

}


