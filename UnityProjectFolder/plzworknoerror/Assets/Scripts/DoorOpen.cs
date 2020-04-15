using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Transform FPSCam;
    public float reach;
    private RaycastHit hit;
    public LayerMask doors;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            if(Physics.Raycast(FPSCam.position, FPSCam.forward, out hit, reach, doors)){
                OnDoor ondoor = hit.transform.GetComponent<OnDoor>();
                if(ondoor.isOpened == false){
                    hit.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                    hit.transform.Translate(1f, 0f, 1f);
                    ondoor.isOpened = true;
                }else{
                    hit.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    hit.transform.Translate(-1f, 0f, 1f);
                    ondoor.isOpened = false;
                }
                
            }
        }   
    }
}
