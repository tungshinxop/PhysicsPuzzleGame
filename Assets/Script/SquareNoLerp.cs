using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This is archive
 */
public class SquareNoLerp : MonoBehaviour
{

    //Call the script

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    { 
        //Move right
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
        }

        //Move left
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
        }

        //Move up
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
        }

        //Move down
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
        }
    }
}
