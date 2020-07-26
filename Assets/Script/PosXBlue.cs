using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosXBlue : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(GameObject.Find("PosX").GetComponent<PosX>().isInContact == true)
        {
            if (other.gameObject.tag == "obstacle")
            {
                //Debug.Log("touching");
                GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMovePosX = false;
                //GameObject.Find("_PlayerManager2").GetComponent<LerpMove>().canMovePosX = false;
            }
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            //Debug.Log("touching");
            GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMovePosX = true;
            //GameObject.Find("_PlayerManager2").GetComponent<LerpMove>().canMovePosX = true;
        }

        if (other.gameObject.tag == "playerBlock")
        {
            GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMoveNegX = true;
            //GameObject.Find("_PlayerManager2").GetComponent<LerpMove>().canMoveNegX = true;
        }
    }
}
