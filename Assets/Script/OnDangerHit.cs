using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDangerHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "dangerousBall")
        {
            Destroy(this.gameObject);
            GameObject.Find("_CheckWin").GetComponent<CheckForWin>().Invoke("Restart", GameObject.Find("_CheckWin").GetComponent<CheckForWin>().restartTime);
            
        }
    }
}
