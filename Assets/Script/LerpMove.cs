using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script is called in _PlayerManager and GhostPlayer
/// </summary>
public class LerpMove : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private float startTime;
    public float moveSpeed = 3.0f;

    //This is also called in PosX,PosZ,NegX,NegZ
    public bool isMoving = false;

    //private Animator anim;

    //public GameObject playerCube;
    //private GameObject player;

    //Get PlayerPush script

    private PosX posXScript;
    private NegX negXScript;
    private PosZ posZScript;
    private NegZ negZScript;

    public bool canMovePosX = true;
    public bool canMovePosZ = true;
    public bool canMoveNegX = true;
    public bool canMoveNegZ = true;

    //If isMovingGhost is true: player cannot press Space to create a new block
    //to prevent breaking lerp move calculation
    public bool isMovingGhost = false;

    //Getting the blue block script
    private ObjMovement ObjMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        //player = Instantiate(playerCube, this.transform.position, Quaternion.identity);
        //player.name = "Player";
        //player.transform.parent = this.transform;

        //PlayerPush script
        posXScript = GameObject.Find("PosX").GetComponent<PosX>();

        negXScript = GameObject.Find("NegX").GetComponent<NegX>();

        posZScript = GameObject.Find("PosZ").GetComponent<PosZ>();

        negZScript = GameObject.Find("NegZ").GetComponent<NegZ>();

        //anim = GameObject.Find("Player").GetComponent<Animator>();

        //Get obj block script
        ObjMovementScript = GameObject.Find("ObjectiveBlock").GetComponent<ObjMovement>();



    }

    // Update is called once per frame
    void Update()
    {
        CheckForMovementWithCannon();
    }

    private void StopOverlapSpawn()
    {
        if (this.name == "GhostPlayer")
        {
            if(this.transform.position == GameObject.Find("ObjectiveBlock").GetComponent<ObjMovement>().blueBLockPos)
            {
                GameObject.Find("_CloneManager").GetComponent<ClonePower>().isOverlapped = true;
            }
        }
    }

    //Execute movement base on the present of cannon
    private void CheckForMovementWithCannon()
    {
        //if there is a cannon in the scene
        //only execute movement when the player is not in cannon mode (fps camera)
        if (GameObject.Find("_BulletFactory") != null)
        {
            if (GameObject.Find("_BulletFactory").GetComponent<Cannon>().isInGunMode == false)
            {
                CheckForInput();
                MovePlayer();
            }
        }
        
        //if there is no cannon
        //execute movement normally based on the condition of lerpmove
        else if (GameObject.Find("_BulletFactory") == null)
        {
            CheckForInput();
            MovePlayer();
        }
    }

    //Receive player's input to set the startPos and endPos
    void CheckForInput()
    {
        //Move right
        if (Input.GetKeyDown(KeyCode.D) && isMoving == false && canMovePosX == true && isMovingGhost == false && GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenu>().gameIsPaused == false) 
        {
            //Minus move limit for each movement
            //only minus when player is controlling the opaque cube
            //will minus move limit by 2 when there are two opaque cubes in the scene
            if(this.name != "GhostPlayer")
            {
                GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit--;
                Debug.Log("Move left: " + GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit);
            }
        

            startTime = Time.time;
            startPos = this.transform.position;
            endPos = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
            isMoving = true; //Stop other input
            isMovingGhost = true;
            //Trigger bool for player push script

            //This if is executed when the ghost block is created
            //because there is no trigger for the ghost block
            if (this.GetComponentInChildren<PosX>() != null) 
            {
                //When the ghost block is created 
                //and when it touches objective block
                //no trigger is turn on 
                if (this.GetComponentInChildren<PosX>().isInContact == true)
                {
                    ObjMovementScript.MovePosX();
                }
            }
                
        }

        //Move left
        if (Input.GetKeyDown(KeyCode.A) && isMoving == false && canMoveNegX == true && isMovingGhost == false && GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenu>().gameIsPaused == false)
        {
            //Minus move limit for each movement
            //only minus when player is controlling the opaque cube
            //will minus move limit by 2 when there are two opaque cubes in the scene
            if (this.name != "GhostPlayer")
            {
                GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit--;
                Debug.Log("Move left: " + GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit);
            }

            startTime = Time.time;
            startPos = this.transform.position;
            endPos = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
            isMoving = true;//Stop other input
            isMovingGhost = true;
            //Trigger bool for player push script
            if (this.GetComponentInChildren<NegX>() != null)
            {
                if (this.GetComponentInChildren<NegX>().isInContact == true)
                {
                    ObjMovementScript.MoveNegX();
                }
            }
                
        }


        //Move up
        if (Input.GetKeyDown(KeyCode.W) && isMoving == false && canMovePosZ == true && isMovingGhost == false && GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenu>().gameIsPaused == false)
        {
            //Minus move limit for each movement
            //only minus when player is controlling the opaque cube
            //will minus move limit by 2 when there are two opaque cubes in the scene
            if (this.name != "GhostPlayer")
            {
                GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit--;
                Debug.Log("Move left: " + GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit);
            }

            startTime = Time.time;
            startPos = this.transform.position;
            endPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
            isMoving = true;//Stop other input
            isMovingGhost = true;
            //Trigger bool for player push script

            if (this.GetComponentInChildren<PosZ>() != null)
            {
                if (this.GetComponentInChildren<PosZ>().isInContact == true)
                {
                    ObjMovementScript.MovePosZ();
                }
            }
                
        }

        //Move down
        if (Input.GetKeyDown(KeyCode.S) && isMoving == false && canMoveNegZ == true && isMovingGhost == false && GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenu>().gameIsPaused == false)
        {
            //Minus move limit for each movement
            //only minus when player is controlling the opaque cube
            //will minus move limit by 2 when there are two opaque cubes in the scene
            if (this.name != "GhostPlayer")
            {
                GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit--;
                Debug.Log("Move left: " + GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit);
            }

            //Debug.Log("moving. Reading isInContact as "+negZScript.isInContact);
            //anim.SetTrigger("RotateDown"); //the name of the parameter in the anim controller
            startTime = Time.time;
            startPos = this.transform.position;
            endPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
            isMoving = true;//Stop other input
                            //Trigger bool for player push script
            isMovingGhost = true;
            if (this.GetComponentInChildren<NegZ>() != null)
            {
                if (this.GetComponentInChildren<NegZ>().isInContact == true)
                {
                    Debug.Log("should move negZ");
                    ObjMovementScript.MoveNegZ();
                }
            }
               
        }
     
    }

    //Execute movement based on startPos and endPos
    void MovePlayer()
    {
        if (isMoving == true && isMovingGhost == true)
        {

            float distCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distCovered / 1; //1 because grid is 1x1 == journey length
            this.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            if (Vector3.Distance(this.transform.position, endPos) < 0.05f)
            {
                this.transform.position = endPos;//Put in the right position
                isMoving = false; //Set the movement to true
                isMovingGhost = false;
            }
        }
    }

}
