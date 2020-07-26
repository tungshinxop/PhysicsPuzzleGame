using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this scipt is held in _BulletFactory which is the child of Cannon
/// </summary>
public class Cannon : MonoBehaviour
{
    public Rigidbody bulletHolder;
    public float thrust;
    public bool canEnterGunMode = false;
    public bool isInGunMode = false;
    [SerializeField] private float maxForce = 1000f;
    public float normalisePower;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenu>().gameIsPaused == false)
        {
            Force();
            AbleToShoot();
            GunMode();
            gunModeCam();
            normalisePower = 1 - (thrust / maxForce);
        }           
    }

    //CALLED IN UPDATE
    void FireCannon()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Final power: " + normalisePower);
            //Debug.Log("Pressed V");
            Rigidbody lastestBullet = Instantiate(bulletHolder, this.transform.position, this.transform.rotation);
            lastestBullet.AddRelativeForce(Vector3.forward * thrust);
            thrust = 0;
            GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit -= 1;
        }
    }

    //CALLED IN UPDATE
    void Force()
    {
        if (Input.GetKey(KeyCode.Space) && isInGunMode == true && thrust <maxForce)
        {
            thrust += 10f;
            //Debug.Log("Thrust: " + thrust + "thrust/maxPower: " + (thrust / maxForce) +" max power: " +maxForce);
            //Debug.Log("Force is: " + thrust);
            Debug.Log("Normalise power: " + normalisePower);
        }
    }

    //CALLED IN UPDATE
    void GunMode()
    {
        if(isInGunMode == false)
        {
            EnterGunMode();
        }
        else
        {
            ExitGunMode();
        }
    }

    //CALLED IN UPDATE
    void EnterGunMode()
    {
        if(canEnterGunMode == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isInGunMode = true;
                Debug.Log("Enter gun mode");
            }
        }   
    }

    //CALLED IN UPDATE
    void ExitGunMode()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            canEnterGunMode = false;
            Debug.Log("Leaving gun mode");
            isInGunMode = false;
        }
    }

    //CALLED IN UPDATE
    void AbleToShoot()
    {
        if (GameObject.Find("_BulletFactory").GetComponent<Cannon>().isInGunMode == true)
        {
            FireCannon();
        }
    }

    //CALLED IN UPDATE
    void gunModeCam()
    {
        if (isInGunMode == true)
        {
            GameObject.Find("CannonCamera").GetComponent<Camera>().enabled = true;

        }
        else
        {
            GameObject.Find("CannonCamera").GetComponent<Camera>().enabled = false;

        }
    }

}
