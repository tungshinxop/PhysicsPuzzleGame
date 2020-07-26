using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ForceBarChange();
    }

    void ForceBarChange()
    {
        if(GameObject.Find("Mask") != null)
        {
            GameObject.Find("Mask").GetComponent<SpriteMask>().alphaCutoff = GameObject.Find("_BulletFactory").GetComponent<Cannon>().normalisePower;
        }
    }
}
