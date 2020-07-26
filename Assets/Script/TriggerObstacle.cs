using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObstacle : MonoBehaviour
{
    public GameObject obstacle;
    [SerializeField] private int blockWidth = 1;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerWallOnButtonHit()
    {
        for(int i = 0; i <3; i++)
        {
            GameObject latestCube = Instantiate(obstacle, new Vector3(this.transform.position.x + blockWidth * i, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            latestCube.transform.parent = this.transform;
        }
    }

  
}
