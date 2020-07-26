using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script receive player input and create clone and new block 
/// This script is held in _CloneManager
/// </summary>
public class ClonePower : MonoBehaviour
{
    [SerializeField] private bool isPressed = false;

    public bool isOverlapped = false;

    public GameObject cloneBlock;
    public GameObject playerCube;
    public GameObject newClone;
    public GameObject newBlock;
    public int fIsPress;

    private LerpMove lerpPlayer;
    //private LerpMove lerpGhost;

    // Start is called before the first frame update
    void Start()
    {
        fIsPress = 0;
        lerpPlayer = GameObject.Find("_PlayerManager").GetComponent<LerpMove>();
        //lerpGhost = GameObject.Find("_CloneManager").GetComponent<LerpMove>();
    }


    // Update is called once per frame
    void Update()
    {
        ClonePlace();
        MakeGhostReal();
    }

    void MakeGhostReal()
    {
       
        //This create a ghost clone block that will hold the lerp move script without the triggers
        //This mean that the ghost can move through obstacle
        if (Input.GetKeyDown(KeyCode.F) && isPressed == false && fIsPress ==0)
        {
            //Debug.Log("F");
            //isPressed is set to true so that player cannot create multiple ghost
            isPressed = true;

            //Instantiate a ghost that is in the position of the public holder called newClone
            //This position is often (0,0,0)
            //Player can move the ghost and the value of newClone will change
            newClone = Instantiate(cloneBlock, this.transform.position, Quaternion.identity);
            newClone.name = "GhostPlayer";

            //Turn off the moving script for the original block
            //and player can move the ghost block freely
            lerpPlayer.enabled = false;
            fIsPress = 1;
            //lerpGhost.enabled = true;    
        }   
    }

    void ClonePlace()
    {
        //This only work when player has already created a ghost (pressed F)
        if (isPressed == true && isOverlapped == false)
        {
            if (Input.GetKeyDown(KeyCode.F) && FindObjectOfType<LerpMove>().isMovingGhost == false)
            {
                //Create a vector3 holder that will hold the current position of the ghost block
                //So that ghost position will not be destroy with it parent
                Vector3 ghostPos = newClone.transform.position;

                //Destroy the ghost and instantiate an opaque block 
                Destroy(newClone.gameObject);

                //The opaque block will have the same position with ghost block
                newBlock = Instantiate(playerCube, ghostPos, Quaternion.identity);

                //Set all the trigger of new opaque block so that the new block can move
                //on players' inputs
                //while the original one cannot
                newBlock.GetComponent<LerpMove>().canMoveNegX = true;
                newBlock.GetComponent<LerpMove>().canMovePosX = true;
                newBlock.GetComponent<LerpMove>().canMoveNegZ = true;
                newBlock.GetComponent<LerpMove>().canMovePosZ = true;

                newBlock.name = "_PlayerManager2";

                //Turn on the moving script for the two red blocks that has been turned off
                //when ghost block is created
                newBlock.GetComponent<LerpMove>().enabled = true;
                lerpPlayer.enabled = true;
            }
        }
    }
}
