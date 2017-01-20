using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) //detect objects that enter warp trigger
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ammo") //if an ammo or cat enters the trigger
        {
            Debug.Log("Ammo Detected"); //log that something has entered
                                        // Destroy(other.gameObject); //delete the object
            Rigidbody tempAmmoRigid = other.gameObject.GetComponent<Rigidbody>(); //assign temporary rigid variable as object rigidbody

            //Debug.Log(tempAmmo.GetComponent<Rigidbody>().useGravity);
           if (tempAmmoRigid.useGravity == true) //if gravity for that object is on
            {
                //Debug.Log("gravity is on");
                tempAmmoRigid.useGravity = false; //set its gravity off
                Debug.Log(other.gameObject + "- gravity is off"); //log that we have turned off that object's gravity
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ammo") //if an ammo or cat enters the trigger
        {
            Debug.Log("Ammo Leaving"); //log that something has entered
                                        // Destroy(other.gameObject); //delete the object
            Rigidbody tempAmmoRigid = other.gameObject.GetComponent<Rigidbody>(); //assign temporary rigid variable as object rigidbody

            //Debug.Log(tempAmmo.GetComponent<Rigidbody>().useGravity);
            if (tempAmmoRigid.useGravity == false) //if gravity for that object is off
            {
                //Debug.Log("gravity is on");
                tempAmmoRigid.useGravity = true; //set its gravity on
                Debug.Log(other.gameObject + "- gravity is on"); //log that we have turned on that object's gravity
            }
        }
    }

}
