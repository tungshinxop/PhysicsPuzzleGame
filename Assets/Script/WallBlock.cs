using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlock : MonoBehaviour
{
    private LerpMove playerManager;

  
    void Start()
    {
        playerManager = GameObject.Find("_PlayerManager").GetComponent<LerpMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("inside");
        if (collision.gameObject.tag == "obstacle")
        {
            //Debug.Log("Touching wall");
            playerManager.isMoving = true;
        }
    }
}
