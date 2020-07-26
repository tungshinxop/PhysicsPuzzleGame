using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    [SerializeField]
    private bool canMove = false;

    private Vector3 startPos;
    private Vector3 endPos;
    private float startTime;
    private float journeyLength;

    public Vector3 blueBLockPos;
    public Rigidbody rb;
    public bool notBlocked = false;
    //[SerializeField] private bool kinematicOff = false;


    //private void Update()
    //{
    //    if(kinematicOff == true)
    //    {
    //        rb.isKinematic = false;
    //    }
    //}
    public void Update()
    {
        blueBLockPos = this.transform.position;
    }

    //Set trigger canMove to true on trigger enter
    public void MovePosX()
    {
        if(notBlocked == false)
        //Debug.Log("Move script turned on");
        startPos = this.transform.position;
        endPos = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos, endPos);
        canMove = true;
        
    }

    public void MoveNegX()
    {
        Debug.Log("Move script turned on");
        startPos = this.transform.position;
        endPos = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);

        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos, endPos);
        canMove = true;
        
    }

    public void MovePosZ()
    {
        Debug.Log("Move script turned on");
        startPos = this.transform.position;
        endPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos, endPos);
        canMove = true;
        
    }

    public void MoveNegZ()
    {
        Debug.Log("Move script turned on");
        startPos = this.transform.position;
        Debug.Log("startPos NegZ:" + startPos);
        endPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
        Debug.Log("endPos negZ: " + endPos);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos, endPos);
        canMove = true;
        
    }

    //Execute move each frame canMove == true
    private void FixedUpdate()
    {
        if(canMove == true)
        {
            //Debug.Log("canMove");
            //Debug.Log("Check for fixed update");
            float distCovered = (Time.time - startTime) * moveSpeed;
            //Debug.Log("distCover");
            float fractionOfJourney = distCovered / journeyLength;
            //Debug.Log("fraction");
            this.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            //Debug.Log("lerp being done");
            if (Vector3.Distance(this.transform.position, endPos) < 0.05f)
            {
                this.transform.position = endPos; //Snap the obj on to the endPos near the end of the movement
                canMove = false; //Stop movement
               // Debug.Log("If trigger");
            }
        }        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "ghostBlock")
    //    {
    //        rb.isKinematic = true;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if(collision.gameObject.tag == "ghostBlock")
    //    {
    //        rb.isKinematic = false;
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "goalFloor")
    //    {
    //        Debug.Log("obj touching goal floor");
    //        FindObjectOfType<CheckForWin>().isWon = true;
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "goalFloor")
    //    {
    //        Debug.Log("obj touching goal floor");
    //        FindObjectOfType<CheckForWin>().checkingWinningCondition = true;
    //    }
    //}



}
