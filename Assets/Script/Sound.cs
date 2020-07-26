using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip explosion;
    private AudioSource aSource;

    private CheckForWin checkWinScript;
    bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        checkWinScript = GameObject.Find("_CheckWin").GetComponent<CheckForWin>();
        aSource = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (checkWinScript.isWon == false && isPlaying == false)
        {
            Debug.Log("sound check");
            isPlaying = true;
            aSource.PlayOneShot(explosion, 1f);
            //AudioSource.PlayClipAtPoint(explosion, this.transform.position);
        }
    }

    
   
       

}
