using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script is held in the muzzle which is the child of cannon
/// </summary>
public class CannonRotate : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CannonControl();
    }

    //Called in Update()
    void CannonControl()
    {
        if(GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenu>().gameIsPaused == false)
        {
            if (GameObject.Find("_BulletFactory").GetComponent<Cannon>().isInGunMode == true)
            {
                //Rotate from right to left
                //+y
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Debug.Log("rot +y = " + this.transform.rotation.y);
                    if (this.transform.rotation.y <= 0.45f)
                    {
                        transform.Rotate(0, 1, 0);
                    }

                }
                //Rotate left
                //-y
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Debug.Log("rot -y = " + this.transform.rotation.y);
                    if (this.transform.rotation.y >= -0.45f)
                    {
                        transform.Rotate(0, -1, 0);
                    }
                }
                //Rotate up
                //+z
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Debug.Log("rot +z = " + this.transform.rotation.z);
                    if (this.transform.rotation.z <= 0.73f)
                    {
                        transform.Rotate(0, 0, 1);
                    }
                }
                //Rotate down
                //-z
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Debug.Log("rot -z = " + this.transform.rotation.z);
                    if (this.transform.rotation.z >= -0.30f)
                    {
                        transform.Rotate(0, 0, -1);
                    }
                }


                //rotate muzzle
                //rotate down
                if (Input.GetKey(KeyCode.Z))
                {
                    transform.Rotate(1, 0, 0);
                }
                //rotate up
                if (Input.GetKey(KeyCode.X))
                {
                    transform.Rotate(-1, 0, 0);
                }
            }
        }
    }
}
