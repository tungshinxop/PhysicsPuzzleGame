﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosXGhost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ObjectiveBlock")
        {
            Debug.Log("Ghost PosX touching blue");
            GameObject.Find("GhostPlayer").GetComponent<LerpMove>().canMovePosX = false;
        }

        if (other.name == "_PlayerManager")
        {
            GameObject.Find("GhostPlayer").GetComponent<LerpMove>().canMovePosX = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "ObjectiveBlock")
        {
            Debug.Log("Ghost PosX leaving blue, byee");
            GameObject.Find("GhostPlayer").GetComponent<LerpMove>().canMovePosX = true;
        }
        if(other.name == "_PlayerManager")
        {
            GameObject.Find("GhostPlayer").GetComponent<LerpMove>().canMovePosX = true;
        }
    }
}
