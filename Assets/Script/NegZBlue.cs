using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegZBlue : MonoBehaviour
{
    ////private void OnTriggerEnter(Collider other)
    ////{
    ////    if (GameObject.Find("PosZ").GetComponent<PosZ>().isInContact == true)
    ////    {
    ////        if (other.gameObject.tag == "obstacle")
    ////        {
    ////            Debug.Log("touching");
    ////            GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMovePosZ = false;
    ////        }
    ////    }
    ////}

    //private void OnTriggerStay(Collider other)
    //{
    //    if (GameObject.Find("PosZ").GetComponent<PosZ>().isInContact == true)
    //    {
    //        if (other.gameObject.tag == "obstacle")
    //        {
    //            Debug.Log("touching");
    //            GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMovePosZ = false;
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "obstacle")
    //    {
    //        Debug.Log("leaving");
    //        GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMovePosZ = true;
    //    }


    //    if (other.gameObject.tag == "playerBlock")
    //    {
    //        GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMoveNegZ = true;
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (GameObject.Find("NegZ").GetComponent<NegZ>().isInContact == true)
        {
            if (other.gameObject.tag == "obstacle")
            {
                Debug.Log("touching");
                GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMoveNegZ = false;
                //GameObject.Find("_PlayerManager2").GetComponent<LerpMove>().canMoveNegZ = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            Debug.Log("touching");
            GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMoveNegZ = true;
            //GameObject.Find("_PlayerManager2").GetComponent<LerpMove>().canMoveNegZ = true;
        }


        if (other.gameObject.tag == "playerBlock")
        {
            GameObject.Find("_PlayerManager").GetComponent<LerpMove>().canMovePosZ = true;
            //GameObject.Find("_PlayerManager2").GetComponent<LerpMove>().canMovePosZ = true;
        }
    }
}
