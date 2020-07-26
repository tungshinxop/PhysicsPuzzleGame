using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This is archive
 */
public class SquareMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce;
    public float sidewayForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W pressed");

            //Time.deltaTime = the amount of second since the last frame
            //Even out the force
            rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange); //Add forward force for player
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("W pressed");

            //Time.deltaTime = the amount of second since the last frame
            //Even out the force
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime, ForceMode.VelocityChange); //Add forward force for player
        }

        if (Input.GetKey(KeyCode.A)) //Add left force for player
        {
            //Debug.Log("A pressed");

            //VelocityChange ignore the momentum
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
         
        if (Input.GetKey(KeyCode.D)) //Add right force for player
        {
            //Debug.Log("D pressed");
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
