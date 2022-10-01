using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody rig;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Get x and z inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;//A & D or left arrow and right arrow movement
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //Set the velocity based on our inputs
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        //This is to prevent the character from falling forward
        Vector3 vel = rig.velocity;
        vel.y = 0;

        //Only look in the direction that we are moving when the character is moving
        if(vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //I'm only really going to need Force and impulse (Force = gradual force, Impulse = instant velocity)
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision?.contacts[0].normal == Vector3.up)//Are we in contact with the ground, 'normal' is (perpendicular?) line from surface/collider/capsule
        {
            isGrounded = true;
        }
    }
}
