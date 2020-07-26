using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBridge : MonoBehaviour
{
    public GameObject ballHolder;
    public GameObject triggerBridge;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "cannonAmmo")
        {
            triggerBridge.SetActive(true);
            Destroy(ballHolder.gameObject);
        }
    }
}
