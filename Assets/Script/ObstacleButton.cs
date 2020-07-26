using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleButton : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cannonAmmo")
        {
            Debug.Log("Hitted Brown");
            GameObject.Find("TriggerObstacle").GetComponent<TriggerObstacle>().TriggerWallOnButtonHit();
        }
    }
}
