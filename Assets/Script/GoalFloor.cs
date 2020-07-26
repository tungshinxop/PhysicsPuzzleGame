using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFloor : MonoBehaviour
{
    
    private CameraFollow cameraFollowScript;

    private void Start()
    {
        cameraFollowScript = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "objectiveBlock")
        {
            Destroy(this.gameObject);
            cameraFollowScript.isFallingWon = true;
            GameObject.Find("ObjectiveBlock").GetComponent<ParticleLauncher>().blueBlockParticleIsOn = true;
        }
    }
}
