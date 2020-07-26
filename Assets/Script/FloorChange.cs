using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Date created: 17/11/2019
Creator: Tung
Purpose: Turn off main floor and turn on alternative floor on players' input
This script is held in the _GameManager in the hierarchy
*/
public class FloorChange : MonoBehaviour
{
    //Create a GameObject variable that store the board object in the hiearchy
    public GameObject board;

    //Create a GameObject variable that store the VisionBoard object in the hiearchy
    public GameObject VisionBoard;

    //bools that change based on players' input(s)
    [SerializeField] private bool vision = false;


    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("board");

        VisionBoard = GameObject.Find("VisionBoard");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        FloorOff();
    }

    //This function will check for players' input 
    //and set bool vision = true if players hold V
    //vision = false if players release V
    //This function is called in Update() in FloorChange script
    void PlayerInput()
    {
        if (Input.GetKey(KeyCode.V))
        {
            vision = true;
            Debug.Log("V hold");
        }
        else
        {
            vision = false;
        }
    }

    //This function check for bool vision
    //if vision is on turn off the main floor
    //if vision is off do nothing
    //This function is called in Update() in FloorChange script
    void FloorOff()
    {
        if(vision == true)
        {
            //Turn off board
            //when player hold down V
            board.gameObject.SetActive(false);
        }
        else
        {
            //Turn on board
            //when players release V
            board.gameObject.SetActive(true);
        }
    }
}
