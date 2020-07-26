using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    //This is set to true when blue block touched goalFloor
    //set in GoalFloor script in goalFloor
    public bool blueBlockParticleIsOn = false;
    public GameObject bluePLauncher;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blueBlockParticleIsOn == true)
        {
            StartCoroutine(ActiveParticle());
        }
    }


 

    IEnumerator ActiveParticle()
    {
        yield return new WaitForSeconds(1.5f);
        bluePLauncher.SetActive(true);    
        
    }
}
