using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCannonHit : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cannonAmmo")
        {
            Destroy(this.gameObject);
            GameObject.Find("_CheckWin").GetComponent<CheckForWin>().Invoke("Restart", GameObject.Find("_CheckWin").GetComponent<CheckForWin>().restartTime);
        }
    }
}
