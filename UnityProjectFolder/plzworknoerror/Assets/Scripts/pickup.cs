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
    public Transform Pickupdestination;
    public GameObject target;

    public bool somethinginhand;


    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && somethinginhand == false)
        {
            if (Physics.Raycast(FPScamera.transform.position, FPScamera.transform.forward, out hit, pickuprange, layermask))
            {
                somethinginhand = true;
                target = hit.collider.transform.gameObject;
                target.GetComponent<Rigidbody>().useGravity = false;
                target.GetComponent<Collider>().enabled = false;
                target.transform.position = Pickupdestination.position;
                target.transform.rotation = Pickupdestination.rotation;
                target.transform.SetParent(Pickupdestination);
                Debug.Log("picked something up");
            }
        }

        if (somethinginhand == true && Input.GetKey(KeyCode.Q))
        {

            somethinginhand = false;
            target.GetComponent<Collider>().enabled = true;
            target.GetComponent<Rigidbody>().useGravity = true;
            target.transform.SetParent(null);
            Debug.Log("hopefully dropped something");
        }
    }








    

}


