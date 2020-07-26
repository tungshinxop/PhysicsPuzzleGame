using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegX : MonoBehaviour
{
    public bool isInContact = false;
    //Check trigger condition on

    private LerpMove playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("_PlayerManager").GetComponent<LerpMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ObjectiveBlock")
        {
            Debug.Log("Touching blue cube");
            isInContact = true;
        }

        //if (other.gameObject.tag == "obstacle")
        //{
        //    Debug.Log("NegX blocked");
        //    playerManager.canMoveNegX = false;
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            //Debug.Log("NegX blocked");
            GetComponentInParent<LerpMove>().canMoveNegX = false;
        }

        if (other.gameObject.tag == "cannon")
        {
            GetComponentInParent<LerpMove>().canMoveNegX = false;
            GameObject.Find("_BulletFactory").GetComponent<Cannon>().canEnterGunMode = true;
        }
    }

    //Check trigger condition off
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ObjectiveBlock")
        {
            isInContact = false;
        }
        
        if (other.gameObject.tag == "obstacle")
        {
            GetComponentInParent<LerpMove>().canMoveNegX = true;
        }

        if (other.gameObject.tag == "cannon")
        {
            GameObject.Find("_BulletFactory").GetComponent<Cannon>().canEnterGunMode = false;
            GetComponentInParent<LerpMove>().canMoveNegX = true;
        }
    }
}
