using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegZ : MonoBehaviour
{

    public bool isInContact = false;

    private LerpMove playerManager;

    // Start is called before the first frame update
    void Start()
    {
        //playerManager = GameObject.Find("_PlayerManager").GetComponent<LerpMove>();
    }
    //Check trigger condition on
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ObjectiveBlock")
        {
            //Debug.Log("Touching blue cube");
            isInContact = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            GetComponentInParent<LerpMove>().canMoveNegZ = false;
        }

        if (other.gameObject.tag == "cannon")
        {
            GetComponentInParent<LerpMove>().canMoveNegZ = false;
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
            GetComponentInParent<LerpMove>().canMoveNegZ = true;
        }

        if (other.gameObject.tag == "cannon")
        {
            GameObject.Find("_BulletFactory").GetComponent<Cannon>().canEnterGunMode = false;
            GetComponentInParent<LerpMove>().canMoveNegZ = true;
        }
    }
}
