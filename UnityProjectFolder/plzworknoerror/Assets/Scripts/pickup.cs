using System;
using System.Collections;
using UnityEngine;

public class pickup : MonoBehaviour
{
    Rigidbody body;
    int layermask = 1 << 10;
    public Camera FPScamera;
    public RaycastHit hit;
    public float pickuprange;
    public LayerMask pickupableobjects;
    public float pickupspeed;
    public Transform Pickupdestination;
    public bool somethinginhand;
    /* public Transform PickDest;
private void OnMouseDown()
{
GetComponent<Rigidbody>().useGravity = false;
this.transform.position = PickDest.position;
this.transform.parent = GameObject.Find("pickupdest").transform;
}

private void OnMouseUp()
{
this.transform.parent = null;
GetComponent<Rigidbody>().useGravity = true;
} //this part is used for the pickup of objects */

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(FPScamera.transform.position, FPScamera.transform.forward, out hit, pickuprange, layermask))
            {
                somethinginhand = true;
                Rigidbody body = hit.collider.GetComponent<Rigidbody>();
                body.useGravity = false;
                body.transform.position = Pickupdestination.position; 
                
            }
        }

        if (somethinginhand == true && Input.GetButtonDown("Fire1"))
        {

            somethinginhand = false;
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
        else
            { while(somethinginhand ==true)
                {
                body.transform.position = Pickupdestination.position;
                }
        
            }
    }

}


