using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    private float gravity = -9.81f;
    public float gravityMultiplier = 1f;
    public float jumpHeight = 3f;
    public float airWaitTime = 0.5f;
    public float jumpMovementSpeedDeclineRate;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask ground;
    private bool isGrounded;

    float x;
    float z;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

    if (isGrounded){
        x = Input.GetAxis("Horizontal");        
        z = Input.GetAxis("Vertical");
    } else{
        StartCoroutine("waitingInAir");
    }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * gravityMultiplier* Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator waitingInAir(){
        yield return new WaitForSeconds(airWaitTime);
        while(x != 0 || z != 0){
            while(x != 0){
                if(x > 0){
                x -= jumpMovementSpeedDeclineRate;    
                }else if(x <0){
                x += jumpMovementSpeedDeclineRate;
                }
            }
            while(x != 0){
                if(z > 0){
                x -= jumpMovementSpeedDeclineRate;    
                }else if(z <0){
                x += jumpMovementSpeedDeclineRate;
                }
            }
        }
    }
}
