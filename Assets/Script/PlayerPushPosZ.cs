using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushPosZ : MonoBehaviour
{
  
    public bool isInContact = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Check trigger condition on
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ObjectiveBlock")
        {
            Debug.Log("Touching blue cube");
            isInContact = true;
        }
    }

    //Check trigger condition off
    private void OnTriggerExit(Collider other)
    {
        isInContact = false;
    }
}
