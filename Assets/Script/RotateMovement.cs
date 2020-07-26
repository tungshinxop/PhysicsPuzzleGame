using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject center;
    public GameObject down;

    public int step = 9;

    public float speed = 0.01f;

    public bool playerInput = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput == true)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine("MoveDown");
                playerInput = false;
            }
        }
    }

    IEnumerator MoveDown()
    {
        for (int i =0; i<(90/step); i++)
        {
            player.transform.RotateAround(down.transform.position, -Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        playerInput = true;
    }
}
