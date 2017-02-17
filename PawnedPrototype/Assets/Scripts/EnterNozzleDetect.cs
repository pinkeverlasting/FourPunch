using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNozzleDetect : MonoBehaviour
{
    //private GameObject backpackObject;
    GameObject redAmmo, blueAmmo, yellowAmmo, whiteAmmo; //stores prebuilt ammo for reference
    public GameObject redActual, blueActual, yellowActual, whiteActual, redBullet, blueBullet; //stores the reference to in world ammo and the bullets
    
    GameObject pack; //stores where the backpack is
    GameObject currentBullet;

    string currentAmmoType; //for tracking current ammo type in the gun
    // Use this for initialization
    private GameObject warpZone; //for tracking the warp zone trigger
    private GameObject warpTexture;
    private GameObject nozzleObject; //for tracking the nozzle of the gun
    private GameObject player;

    public int blueAmmoCount;
    private int currentBlueAmmoCount;

    [SerializeField] private int ejectSpeed; //for storing the speed with which you eject the ammo
    [SerializeField] private int fireSpeed; //for storing the speed with which you fire the bullet

	bool allowToEject;

    public enum GunState //enumirator for storing the different states of the gun
    {
        VACUUM,
        GUN,
        EJECT
    };

    public GunState stateOfGun; //public variable for storing the state of the gun

    void Start()
    {
        //backpackObject = GameObject.Find("Backpack");
        warpZone = GameObject.Find("WarpTrigger"); //find the warp trigger
        nozzleObject = GameObject.Find("NozzleTrigger");
        warpTexture = GameObject.Find("SuckingEffect");

        redAmmo = GameObject.Find("RedAmmoCont"); //find the red ammo
        blueAmmo = GameObject.Find("BlueAmmoCont"); //find the blue ammo
        yellowAmmo = GameObject.Find("YellowAmmoCont");
        whiteAmmo = GameObject.Find("WhiteAmmoCont");

        pack = GameObject.Find("Backpack"); //find the backpack
        player = GameObject.Find("Player");
        stateOfGun = GunState.VACUUM;

		allowToEject = false;

        currentBlueAmmoCount = blueAmmoCount;
        //Debug.Log(warpZone.GetComponent<ObjectDetect>().multipplier);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(1) && stateOfGun == GunState.GUN && allowToEject) //if right click and the gun is in gun mode
        {
            //int tempAmmoType;
            //Debug.Log("hit right mouse when GUN");
            stateOfGun = GunState.EJECT; //set gun mode to eject
            foreach(Transform child in pack.transform) //check the children of the backpack
            {
                EjectAmmo((int)child.GetComponent<AmmoTypeScript>().catType); //check the ammo type and send it to EjectAmmo
                Destroy(child.gameObject); //destroy the child
            }
			allowToEject = false;
            Invoke("ResetToVacuum", 3); //set a delay to reseting the gun back to vacuum
            //SET TIMER TO SWITCH BACK TO VACUUM
        } else if (Input.GetMouseButtonDown(0) && stateOfGun == GunState.GUN) //if left click and the gun is in gun mode
        {
            //ADD MORE AMMO TYPES
            if (currentAmmoType == "BLUE")
            {
                if(currentBlueAmmoCount > 0)
                {
                    LaunchAmmo(fireSpeed);
                    currentBlueAmmoCount -= 1;
                }
                else
                {
                    //Set cat ammo to white cat
                }
               
               
            }
            else if(currentAmmoType == "RED")
            {
                LaunchAmmo(fireSpeed * 1.5f);
            }
            else if (currentAmmoType == "YELLOW")
            {
                LaunchAmmo(0);
            }
            //Debug.Log(currentAmmoType);
        }
    }

    private void EjectAmmo(int type) //for ejecting specific ammo types DETECTS AMMO TYPES
    {
        //ADD MORE AMMO TYPES
        if (type == 0) //ammo is RED
        {
            Debug.Log("Ejecting RED ammo");
            GameObject tempAmmoObject = Instantiate(redActual, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temp ammo as the instantiated ammo
            tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * ejectSpeed); //add the ejection force to it
        }
        else if(type == 1) //ammo is BLUE
        {
            Debug.Log("Detected BLUE ammo");
            GameObject tempAmmoObject = Instantiate(blueActual, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temp ammo as the instantiated ammo
            tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * ejectSpeed); //add the ejection force to it
        }
        else if (type == 2) //ammo is YELLOW
        {
            Debug.Log("Detected YELLOW ammo");
            GameObject tempAmmoObject = Instantiate(yellowActual, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temp ammo as the instantiated ammo
            tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * ejectSpeed); //add the ejection force to it
        }
        else if (type == 3) //ammo is WHITE
        {
            Debug.Log("Detected WHITE ammo");
            GameObject tempAmmoObject = Instantiate(whiteActual, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temp ammo as the instantiated ammo
            tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * ejectSpeed); //add the ejection force to it
        }
    }

    private void ResetToVacuum() //resets gun back to vacuum
    {
        Debug.Log("Resetting back to Vacuum");
        stateOfGun = GunState.VACUUM; //set gun state to vacuum
    }

	private void VacuumToEjectCooldown(){
		Debug.Log("Now allowed to eject");
		allowToEject = true;
	}

    private void LaunchAmmo(float fSpeed)
    {
        GameObject tempAmmoObject = Instantiate(currentBullet, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temporary bullet as the instantiated bullet
        tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * fSpeed); //add the fire force to bullet
    }

    private void OnTriggerEnter(Collider other) //detect objects that enter warp trigger
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ammo" && other.gameObject.GetComponent<AmmoTypeScript>()!=null && stateOfGun == GunState.VACUUM) //if an ammo or cat enters the trigger and it has a script and the gun is in vacuum mode
        {
            //other.gameObject.GetComponent<AmmoTypeScript>();
           // Debug.Log(other.gameObject.GetComponent<AmmoTypeScript>().catType);
            //Debug.Log("Ammo @ Nozzle"); //log that something has entered
            if (other.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.RED) //if it's red ammo DETECTS AMMO TYPES|ADD MORE AMMO HERE
            {
                //Debug.Log("Ammo is RED");
                foreach (Transform child in pack.transform) //delete all children in backpack
                {
                    GameObject.Destroy(child.gameObject);
                }
                currentAmmoType = AmmoTypeScript.AmmoType.RED.ToString(); //track current ammo as red
                Instantiate(redAmmo,pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack
                currentBullet = redBullet; //set current bullet type to red bullet
                
            }
            else if (other.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.BLUE) //if it's blue ammo
            {
                foreach (Transform child in pack.transform) //delete all children in backpack
                {
                    GameObject.Destroy(child.gameObject);
                }
                //Debug.Log("Ammo is RED");
                currentAmmoType = AmmoTypeScript.AmmoType.BLUE.ToString(); //track current ammo as blue
                Instantiate(blueAmmo, pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack
                currentBullet = blueBullet; //set current bullet type to blue bullet
                currentBlueAmmoCount = blueAmmoCount;
            }
            else if (other.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.YELLOW) //if it's blue ammo
            {
                foreach (Transform child in pack.transform) //delete all children in backpack
                {
                    GameObject.Destroy(child.gameObject);
                }
                //Debug.Log("Ammo is RED");
                currentAmmoType = AmmoTypeScript.AmmoType.YELLOW.ToString(); //track current ammo as blue
                Instantiate(yellowAmmo, pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack
                currentBullet = redBullet; //set current bullet type to blue bullet
               
            }
            else if (other.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.WHITE) //if it's blue ammo
            {
                foreach (Transform child in pack.transform) //delete all children in backpack
                {
                    GameObject.Destroy(child.gameObject);
                }
                //Debug.Log("Ammo is RED");
                currentAmmoType = AmmoTypeScript.AmmoType.WHITE.ToString(); //track current ammo as blue
                Instantiate(whiteAmmo, pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack
                currentBullet = null; //set current bullet type to blue bullet

            }

            warpTexture.GetComponent<suckingDisplay>().SendMessage("DisableVortex");

            Destroy(other.gameObject); //destroy the collided object

            warpZone.GetComponent<ObjectDetect>().ResetMultiplier(); //reset the gravity multiplier of the gun

			Invoke("VacuumToEjectCooldown", 2);

            stateOfGun = GunState.GUN; //set the gun to gun mode

            player.GetComponent<PlayerMovement>().SetToWalkingSpeed();

            Debug.Log("CurrentAmmo: " + currentAmmoType); //log the current ammo type
           

           //other.gameObject.transform.position = backpackObject.transform.position;
           //other.gameObject.transform.SetParent(backpackObject.transform);
           // other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
           // other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            //other.gameObject.GetComponent<Collider>().isTrigger = true;

        }
    }
}
