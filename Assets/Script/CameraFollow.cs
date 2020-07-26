using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Purpose: Make the camera follow the blue cube when winning condition is set to true
This script is held in Main Camera
*/
public class CameraFollow : MonoBehaviour
{
    //Create a bool that check if the objective block is falling or not
    //If it is falling => set bool to true
    //else => set it to false
    //this is also held in GoalFloor script in goalFloor in the hierarchy
    public bool isFallingWon = false;

    //Create an object that can be transformed
    //Target is the holder for Objective Block
    public Transform target;

    //Change the smooth time for snapping (from 0 to 1 is ok)
    public float smoothSpeed = 0.125f;

    //Using vector sum
    //to add an offset (gap) between the position of the camera and Objective block
    public Vector3 offset; 

    //Create a function that is always active
    //Uses fixed update for smooth lerp
    void FixedUpdate()
    {
        if(isFallingWon == true)
        {
            //Set a Vector3 called desiredPosition 
            //which will be the end position of the camera when isFalling is set to true
            Vector3 desiredPosition = target.position + offset;

            //Make the camera follow
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
