using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetect : MonoBehaviour {

    private GameObject nozzle;
    private Vector3 nozzlePosition;

    public float multipplier;
    public float originalMultiplier;

	// Use this for initialization
	void Start () {
        nozzle = GameObject.Find("NozzleTrigger");
        originalMultiplier = multipplier;
        //nozzlePosition = nozzle.GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
        nozzlePosition = nozzle.GetComponent<Transform>().position;
       
    }

    private void OnTriggerEnter(Collider other) //detect objects that enter warp trigger
    {
        //Debug.Log(other.gameObject.tag);
        /*if (other.gameObject.tag == "Ammo") //if an ammo or cat enters the trigger
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
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButton(1)) //if right click is down
        {

            //Debug.Log("True");
            if (other.gameObject.tag == "Ammo") //if an ammo or cat enters the trigger
            {
                Rigidbody tempAmmoRigid = other.gameObject.GetComponent<Rigidbody>(); //assign temporary rigid variable as object rigidbody

                //Debug.Log(tempAmmo.GetComponent<Rigidbody>().useGravity);
                if (tempAmmoRigid.useGravity == true) //if gravity for that object is on
                {
                    //Debug.Log("gravity is on");
                    tempAmmoRigid.useGravity = false; //set its gravity off
                    Debug.Log(other.gameObject + "- gravity is OFF"); //log that we have turned off that object's gravity
                }

                //Debug.Log("still inside");
                //Debug.Log(nozzlePosition);

                //Debug.Log(multipplier);

                //Transform tempObjectTransform = other.gameObject.GetComponent<Transform>();
                multipplier = multipplier * 1.2f; //multiply the gravity multiplier of the warp field


                other.GetComponent<Rigidbody>().AddForce((nozzlePosition - other.transform.position) * multipplier); //add the vacuum force to the object

            }
        }
        else if (Input.GetMouseButtonUp(1)) //if let go of right click
        {
            if (other.gameObject.tag == "Ammo") //if an ammo or cat enters the trigger
            {
                Rigidbody tempAmmoRigid = other.gameObject.GetComponent<Rigidbody>(); //assign temporary rigid variable as object rigidbody

                //Debug.Log(tempAmmo.GetComponent<Rigidbody>().useGravity);
                if (tempAmmoRigid.useGravity == false) //if gravity for that object is on
                {
                    //Debug.Log("gravity is on");
                    tempAmmoRigid.useGravity = true; //set its gravity off
                    Debug.Log(other.gameObject + "- gravity is ON"); //log that we have turned off that object's gravity
                }
                ResetMultiplier(); //reset the gravity multiplier
            }
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ammo") //if an ammo or cat enters the trigger
        {
            Debug.Log("Ammo Leaving"); //log that something has left
                                        // Destroy(other.gameObject); //delete the object
            Rigidbody tempAmmoRigid = other.gameObject.GetComponent<Rigidbody>(); //assign temporary rigid variable as object rigidbody

            //Debug.Log(tempAmmo.GetComponent<Rigidbody>().useGravity);
            if (tempAmmoRigid.useGravity == false) //if gravity for that object is off
            {
                //Debug.Log("gravity is on");
                tempAmmoRigid.useGravity = true; //set its gravity on
                Debug.Log(other.gameObject + "- gravity is ON"); //log that we have turned on that object's gravity
                ResetMultiplier(); //reset the gravity multiplier
                //multipplier = originalMultiplier;
            }
        }
    }

    public void ResetMultiplier() //for reseting the gravity multiplier of the warp field
    {
        multipplier = originalMultiplier; //the multiplier equels the original multiplier value
    }

}
