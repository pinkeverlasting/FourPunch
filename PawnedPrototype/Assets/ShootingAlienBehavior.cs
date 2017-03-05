using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAlienBehavior : MonoBehaviour {

    public GameObject currentBullet;
    public GameObject nozzleObject;
    public GameObject testWall;
    private float fSpeed;
    private bool canFire;
	// Use this for initialization
	void Start () {
        fSpeed = 1000;
        canFire = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (canFire)
        {
            GameObject tempAmmoObject = Instantiate(currentBullet, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temporary bullet as the instantiated bullet
            if (testWall != null)
            {
                Physics.IgnoreCollision(tempAmmoObject.GetComponent<Collider>(), testWall.GetComponent<Collider>()); //USE THIS TO LET BULLETS THROUGH WALLS
            }

            tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * fSpeed); //add the fire force to bullet
            canFire = false;
            Invoke("ResetCanFire", 1f);
        }
       
    }

    void ResetCanFire()
    {
        canFire = true;
    }
}
