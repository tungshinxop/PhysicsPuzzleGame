using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class negZGhost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ObjectiveBlock")
        {
            //Debug.Log("Ghost PosX touching blue");
            GameObject.Find("GhostPlayer").GetComponent<LerpMove>().canMoveNegZ = false;
        }

        //if (other.name == "_PlayerManager")
        //{
        //    GameObject.Find("GhostPlayer").GetComponent<LerpMove>().canMoveNegZ = false;
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "ObjectiveBlock")
        {
            //Debug.Log("Ghost PosX touching blue");
            GameObject.Find("GhostPlayer").GetComponent<LerpMove>().canMoveNegZ = false;
        }

        //if (other.name == "_PlayerManager")
        //{
        //    GameObject.Find("GhostPlayer").GetComponent<LerpMove>().canMoveNegZ = false;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ObjectiveBlock")
        {
            //Debug.Log("Ghost PosX leaving blue, byee");
            GameObject.Find("GhostPlayer").GetComponent<LerpMove>().canMoveNegZ = true;
        }

        if(other.name == "_PlayerManager")
        {
            GameObject.Find("GhostPlayer").GetComponent<LerpMove>().canMoveNegZ = true;
        }
    }
}
