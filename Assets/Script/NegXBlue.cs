using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegXBlue : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (GameObject.Find("NegX").GetComponent<NegX>().isInContact == true)
        {
            if (other.gameObject.tag == "obstacle")
            {
                Debug.Log("touching");
                GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMoveNegX = false;
                //GameObject.Find("_PlayerManager2").GetComponent<LerpMove>().canMoveNegX = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            Debug.Log("touching");
            GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMoveNegX = true;
            //GameObject.Find("_PlayerManager2").GetComponent<LerpMove>().canMoveNegX = true;
        }


        if (other.gameObject.tag == "playerBlock")
        {
            GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMovePosX = true;
            //GameObject.Find("_PlayerManager2").GetComponent<LerpMove>().canMovePosX = true;
        }
    }
}
