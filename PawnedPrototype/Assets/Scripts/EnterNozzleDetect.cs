using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNozzleDetect : MonoBehaviour
{
    //private GameObject backpackObject;
    GameObject redAmmo, blueAmmo; //stores prebuilt ammo for reference
    GameObject pack; //stores where the backpack is

    string currentAmmoType; //for tracking current ammo type in the gun
    // Use this for initialization
    private GameObject warpZone; //for tracking the warp zone trigger

    enum GunState //enumirator for storing the different states of the gun
    {
        VACUUM,
        GUN,
        EJECT
    };

    void Start()
    {
        //backpackObject = GameObject.Find("Backpack");
        warpZone = GameObject.Find("WarpTrigger"); //find the warp trigger
        redAmmo = GameObject.Find("RedAmmoCont"); //find the red ammo
        blueAmmo = GameObject.Find("BlueAmmoCont"); //find the blue ammo
        pack = GameObject.Find("Backpack"); //find the backpack
        //Debug.Log(warpZone.GetComponent<ObjectDetect>().multipplier);
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    private void OnTriggerEnter(Collider other) //detect objects that enter warp trigger
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ammo" && other.gameObject.GetComponent<AmmoTypeScript>()!=null) //if an ammo or cat enters the trigger and it has a script
        {
            //other.gameObject.GetComponent<AmmoTypeScript>();
           // Debug.Log(other.gameObject.GetComponent<AmmoTypeScript>().catType);
            //Debug.Log("Ammo @ Nozzle"); //log that something has entered
            if (other.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.RED) //if it's red ammo
            {
                //Debug.Log("Ammo is RED");
                foreach (Transform child in pack.transform) //delete all children in backpack
                {
                    GameObject.Destroy(child.gameObject);
                }
                currentAmmoType = AmmoTypeScript.AmmoType.RED.ToString(); //track current ammo as red
                Instantiate(redAmmo,pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack
                
            }
            else if (other.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.BLUE) //if it's blue ammo
            {
                foreach (Transform child in pack.transform) //delete all children in backpack
                {
                    GameObject.Destroy(child.gameObject);
                }
                //Debug.Log("Ammo is RED");
                currentAmmoType = AmmoTypeScript.AmmoType.RED.ToString(); //track current ammo as blue
                Instantiate(blueAmmo, pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack

            }

            Destroy(other.gameObject); //destroy the collided object

            warpZone.GetComponent<ObjectDetect>().ResetMultiplier(); //reset the gravity multiplier of the gun

            Debug.Log("CurrentAmmo: " + currentAmmoType); //log the current ammo type
           

           //other.gameObject.transform.position = backpackObject.transform.position;
           //other.gameObject.transform.SetParent(backpackObject.transform);
           // other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
           // other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            //other.gameObject.GetComponent<Collider>().isTrigger = true;

        }
    }
}
