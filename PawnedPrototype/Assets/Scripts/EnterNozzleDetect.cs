using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNozzleDetect : MonoBehaviour
{
	//private GameObject backpackObject;
	GameObject redAmmo, blueAmmo, yellowAmmo, whiteAmmo, purpleAmmo, orangeAmmo, greenAmmo; //stores prebuilt ammo for reference
	public GameObject redActual, blueActual, yellowActual, whiteActual, redBullet, blueBullet, yellowBullet, purpleBullet, orangeBullet, greenBullet; //stores the reference to in world ammo and the bullets

	GameObject pack; //stores where the backpack is
	GameObject currentBullet;

	string currentAmmoType; //for tracking current ammo type in the gun
	string newAmmoType;
	// Use this for initialization
	private GameObject warpZone; //for tracking the warp zone trigger
	private GameObject warpTexture;
	private GameObject nozzleObject; //for tracking the nozzle of the gun
	private GameObject player;

	public int blueAmmoCount;
	public int redAmmoCount;
	public int yellowAmmoCount;
	public int purpleAmmoCount;
	public int orangeAmmoCount;
	public int greenAmmoCount;
	private int currentBlueAmmoCount;
	private int currentRedAmmoCount;
	private int currentYellowAmmoCount;
	private int currentPurpleAmmoCount;
	private int currentOrangeAmmoCount;
	private int currentGreenAmmoCount;

	public bool hasEquipment;
	public bool hasUpgrade;
	public GameObject equipment;
	public GameObject noEquipModel;

	public GameObject testWall;
	public AmmoLight light; 
	public BarrelCooldown barrel; 


	[SerializeField] private int ejectSpeed; //for storing the speed with which you eject the ammo
	[SerializeField] private int fireSpeed; //for storing the speed with which you fire the bullet
	[SerializeField] private float strayFactor;

	bool allowToEject;
	bool noAmmo;

	// Audio Area //
	public AudioSource audio;
	public AudioClip error; 

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
		purpleAmmo = GameObject.Find("PurpleAmmoCont");
		orangeAmmo = GameObject.Find("OrangeAmmoCont");
		greenAmmo = GameObject.Find("GreenAmmoCont");

		pack = GameObject.Find("Backpack"); //find the backpack
		player = GameObject.Find("Player");
		light = GameObject.Find ("LightUI").GetComponent<AmmoLight>();
		light.stateOfAmmo = AmmoLight.AmmoState.NONE;
		barrel = GameObject.Find ("GunBarrel").GetComponent<BarrelCooldown>();
		barrel.stateOfBarrel = BarrelCooldown.BarrelState.NONE;
		stateOfGun = GunState.VACUUM;

		allowToEject = false;
		noAmmo = false;

		currentBlueAmmoCount = blueAmmoCount;

		orangeBullet.SetActive(false);
		greenBullet.SetActive(false);

		if (!hasEquipment)
		{
			equipment.SetActive(false);
		}
		else
		{
			noEquipModel.SetActive(false);
			equipment.SetActive(true);
			hasEquipment = true;
		}
		//Debug.Log(warpZone.GetComponent<ObjectDetect>().multipplier);
	}

	// Update is called once per frame
	void Update()
	{
		if (hasEquipment)
		{
			//Debug.Log(currentAmmoType);
			if (Input.GetKeyDown(KeyCode.Space) && stateOfGun == GunState.GUN && allowToEject) //if right click and the gun is in gun mode
			{
				//int tempAmmoType;
				//Debug.Log("hit right mouse when GUN");
				stateOfGun = GunState.EJECT; //set gun mode to eject
				light.stateOfAmmo = AmmoLight.AmmoState.NONE;
				foreach (Transform child in pack.transform) //check the children of the backpack
				{
					EjectAmmo((int)child.GetComponent<AmmoTypeScript>().catType); //check the ammo type and send it to EjectAmmo
					//EjectAmmo(6);
					Destroy(child.gameObject); //destroy the child
				}
				allowToEject = false;
				barrel.stateOfBarrel = BarrelCooldown.BarrelState.EJECT;
				Invoke("ResetToVacuum", 3); //set a delay to reseting the gun back to vacuum
				//SET TIMER TO SWITCH BACK TO VACUUM
			}
			else if (Input.GetMouseButtonDown(0) && stateOfGun == GunState.GUN) //if left click and the gun is in gun mode
			{
				//ADD MORE AMMO TYPES
				if (currentAmmoType == "BLUE")
				{
					if (currentBlueAmmoCount > 0)
					{
						LaunchAmmo(fireSpeed);
						currentBlueAmmoCount -= 1;
					}
					if (currentBlueAmmoCount <= blueAmmoCount * 0.45f) {
						light.stateOfAmmo = AmmoLight.AmmoState.LOW;
					}
					if (currentBlueAmmoCount <= 1)
					{
						OutOfAmmo();
						light.stateOfAmmo = AmmoLight.AmmoState.FLASH;
					}


				}
				/* else if(currentAmmoType == "RED")
                 {
                     LaunchAmmo(fireSpeed * 1.5f);
                 }*/
				else if (currentAmmoType == "YELLOW")
				{
					if (currentYellowAmmoCount > 0)
					{
						LaunchAmmo(fireSpeed / 2);
						currentYellowAmmoCount -= 1;
					}
					if (currentYellowAmmoCount <= yellowAmmoCount * 0.45f) {
						light.stateOfAmmo = AmmoLight.AmmoState.LOW;
					}

					if (currentYellowAmmoCount <= 1)
					{
						OutOfAmmo();
						light.stateOfAmmo = AmmoLight.AmmoState.FLASH;
					}

				}
				else if (currentAmmoType == "PURPLE")
				{
					if (currentPurpleAmmoCount > 0)
					{
						LaunchAmmo(fireSpeed);
						currentPurpleAmmoCount -= 1;
					}
					if (currentPurpleAmmoCount <= purpleAmmoCount * 0.45f) {
						light.stateOfAmmo = AmmoLight.AmmoState.LOW;
					}

					if (currentPurpleAmmoCount <= 1)
					{
						OutOfAmmo();
						light.stateOfAmmo = AmmoLight.AmmoState.FLASH;
					}

				}

				else if (currentAmmoType == "ORANGE")
				{
					if (orangeBullet.active == false)
					{
						orangeBullet.SetActive(true);
						currentOrangeAmmoCount -= 1;
						Invoke("TurnOffOrange", 0.5f);

					}
					if (currentOrangeAmmoCount <= orangeAmmoCount * 0.45f) {
						light.stateOfAmmo = AmmoLight.AmmoState.LOW;
					}

					if (currentOrangeAmmoCount <= 1)
					{
						OutOfAmmo();
						light.stateOfAmmo = AmmoLight.AmmoState.FLASH;
					}

				}
				else if (currentAmmoType == "GREEN")
				{
					if (greenBullet.active == false && currentGreenAmmoCount > 0)
					{
						greenBullet.SetActive(true);
						currentGreenAmmoCount -= 1;

						Invoke("TurnOffGreen", 1);
						Collider[] colliders = Physics.OverlapSphere(transform.position, 10);
						foreach (Collider hit in colliders)
						{
							GameObject mutantBody = hit.gameObject;

							if (mutantBody != null && mutantBody.tag == "Mutant" && mutantBody.GetComponent<EnemyStatePattern>().alive == true)
							{
								//Debug.Log("I'VE HIT A MUTANT");
								mutantBody.SendMessage("ShockTimer");

								//mutantBody.SendMessage();
							}


						}
					}

					if (currentGreenAmmoCount <= greenAmmoCount * 0.45f) {
						light.stateOfAmmo = AmmoLight.AmmoState.LOW;
					}


					if (currentGreenAmmoCount <= 1)
					{
						OutOfAmmo();
						light.stateOfAmmo = AmmoLight.AmmoState.FLASH;
					}


				}

				//Debug.Log(currentAmmoType);
			}
			if (Input.GetMouseButton(0) && stateOfGun == GunState.GUN && currentAmmoType == "RED")
			{
				if (currentRedAmmoCount > 0)
				{
					LaunchAmmo(fireSpeed * 1.5f);
					currentRedAmmoCount -= 1;
				} 

				if (currentRedAmmoCount <= redAmmoCount * 0.45f) {
					light.stateOfAmmo = AmmoLight.AmmoState.LOW;
				}


				if (currentRedAmmoCount <= 1)
				{
					OutOfAmmo();
					light.stateOfAmmo = AmmoLight.AmmoState.FLASH;

				} 

			}
			if (Input.GetKeyUp (KeyCode.Space) && stateOfGun == GunState.VACUUM && currentAmmoType != null) {
				Invoke ("VacuumToEjectCooldown", 2);

				stateOfGun = GunState.GUN;
				warpTexture.GetComponent<suckingDisplay> ().SendMessage ("DisableVortex");
				player.GetComponent<PlayerMovement> ().SetToWalkingSpeed ();
                barrel.stateOfBarrel = BarrelCooldown.BarrelState.COMPLETE;
                //Invoke("VacuumToEjectCooldown", 2);
            }

			if (Input.GetKeyUp (KeyCode.Space) && !allowToEject && currentAmmoType != null) {
				audio.PlayOneShot(error);
			}
			if (Input.GetMouseButton(0) && noAmmo && stateOfGun == GunState.GUN) {
				audio.PlayOneShot(error);
			}
		}
	}
	private void TurnOffOrange()
	{
		orangeBullet.SetActive(false);
	}
	private void TurnOffGreen()
	{
		//Debug.Log("Called GREEN TURN OFF");
		greenBullet.SetActive(false);
	}

	private void EjectAmmo(int type) //for ejecting specific ammo types DETECTS AMMO TYPES
	{
		noAmmo = false;
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
		else if (type == 4) //ammo is PURPLE
		{
			Debug.Log("Detected RED and BLUE ammo");
			GameObject tempAmmoObject = Instantiate(redActual, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temp ammo as the instantiated ammo
			tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * ejectSpeed * 1.5f); //add the ejection force to it
			EjectAmmo(1);
		}
		else if (type == 5) //ammo is ORANGE
		{
			Debug.Log("Detected RED and YELLOW ammo");
			GameObject tempAmmoObject = Instantiate(redActual, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temp ammo as the instantiated ammo
			tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * ejectSpeed * 1.5f); //add the ejection force to it
			EjectAmmo(2);
		}
		else if (type == 6) //ammo is GREEN
		{
			Debug.Log("Detected BLUE and YELLOW ammo");
			GameObject tempAmmoObject = Instantiate(blueActual, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temp ammo as the instantiated ammo
			tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * ejectSpeed * 1.5f); //add the ejection force to it
			EjectAmmo(2);
		}
	}
	public void ActivateEquipment()
	{
		noEquipModel.SetActive(false);
		equipment.SetActive(true);
		hasEquipment = true;
	}

	private void ResetToVacuum() //resets gun back to vacuum
	{
		Debug.Log("Resetting back to Vacuum");
		currentAmmoType = null;
		currentBullet = null;
		barrel.stateOfBarrel = BarrelCooldown.BarrelState.NONE;
		stateOfGun = GunState.VACUUM; //set gun state to vacuum


	}

	private void VacuumToEjectCooldown(){
		Debug.Log("Now allowed to eject");
		barrel.stateOfBarrel = BarrelCooldown.BarrelState.NONE;
		allowToEject = true;
	}

	private void LaunchAmmo(float fSpeed)
	{
		if(currentAmmoType == "RED")
		{
			float randomNumberX = Random.Range(-strayFactor, strayFactor);
			float randomNumberY = Random.Range(-strayFactor, strayFactor);

			GameObject tempAmmoObject = Instantiate(currentBullet, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temporary bullet as the instantiated bullet
			tempAmmoObject.transform.Rotate(randomNumberX,randomNumberY,0);
			tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * fSpeed); //add the fire force to bullet


			//Debug.Log("SHOOTING RED AMMO");

		}
		else if (currentAmmoType == "PURPLE")
		{
			GameObject tempAmmoObject = Instantiate(currentBullet, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temporary bullet as the instantiated bullet
			tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * fSpeed); //add the fire force to bullet
			tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.up * fSpeed / 6); //add the fire force to bullet
		}
		else
		{
			GameObject tempAmmoObject = Instantiate(currentBullet, nozzleObject.transform.position, nozzleObject.transform.rotation); //set temporary bullet as the instantiated bullet
			if (testWall != null)
			{
				Physics.IgnoreCollision(tempAmmoObject.GetComponent<Collider>(), testWall.GetComponent<Collider>()); //USE THIS TO LET BULLETS THROUGH WALLS
			}

			tempAmmoObject.GetComponent<Rigidbody>().AddForce(tempAmmoObject.transform.forward * fSpeed); //add the fire force to bullet

		}

	}

	private void OutOfAmmo()
	{
		foreach (Transform child in pack.transform) //delete all children in backpack
		{
			GameObject.Destroy(child.gameObject);
		}
		//Debug.Log("Ammo is RED");
		noAmmo = true;
		currentAmmoType = AmmoTypeScript.AmmoType.WHITE.ToString(); //track current ammo as blue
		Instantiate(whiteAmmo, pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack
		currentBullet = null; //set current bullet type to blue bullet
	}

	private void OnTriggerEnter(Collider other) //detect objects that enter warp trigger
	{
		//Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Ammo" && other.gameObject.GetComponent<AmmoTypeScript>()!=null && stateOfGun == GunState.VACUUM) //if an ammo or cat enters the trigger and it has a script and the gun is in vacuum mode
		{
			//other.gameObject.GetComponent<AmmoTypeScript>();
			// Debug.Log(other.gameObject.GetComponent<AmmoTypeScript>().catType);
			//Debug.Log("Ammo @ Nozzle"); //log that something has entered
			if (currentAmmoType == null)
			{
				if (other.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.RED) //if it's red ammo DETECTS AMMO TYPES|ADD MORE AMMO HERE
				{
					//Debug.Log("Ammo is RED");
					foreach (Transform child in pack.transform) //delete all children in backpack
					{
						GameObject.Destroy(child.gameObject);
					}
					currentAmmoType = AmmoTypeScript.AmmoType.RED.ToString(); //track current ammo as red
					Instantiate(redAmmo, pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack
					currentBullet = redBullet; //set current bullet type to red bullet
					currentRedAmmoCount = redAmmoCount;


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
					currentBullet = yellowBullet; //set current bullet type to blue bullet
					currentYellowAmmoCount = yellowAmmoCount;

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
				if (!hasUpgrade)
				{
					stateOfGun = GunState.GUN; //set the gun to gun mode
					barrel.stateOfBarrel = BarrelCooldown.BarrelState.COMPLETE;
					Invoke("VacuumToEjectCooldown", 2);
				}



				//

				//player.GetComponent<PlayerMovement>().SetToWalkingSpeed();

				Debug.Log("CurrentAmmo: " + currentAmmoType); //log the current ammo type
			}
			else if (currentAmmoType != null && hasUpgrade)
			{
				//Debug.Log(other.gameObject.GetComponent<AmmoTypeScript> ().catType);
				newAmmoType = other.gameObject.GetComponent<AmmoTypeScript> ().catType.ToString();
				if (currentAmmoType == newAmmoType || other.gameObject.GetComponent<AmmoTypeScript> ().catType == AmmoTypeScript.AmmoType.WHITE) {
					//Destroy (other.gameObject);
					Invoke ("VacuumToEjectCooldown", 2);
					barrel.stateOfBarrel = BarrelCooldown.BarrelState.COMPLETE;
					stateOfGun = GunState.GUN;
					warpTexture.GetComponent<suckingDisplay> ().SendMessage ("DisableVortex");
					player.GetComponent<PlayerMovement> ().SetToWalkingSpeed ();
				} else {
					Debug.Log("CALL COMBINATOR");
					int combinationCat = 0;
					if (currentAmmoType == "RED") {

						if (newAmmoType == "BLUE") {
							combinationCat = 1; //PURPLE
						} else if (newAmmoType == "YELLOW") {
							combinationCat = 2; //ORANGE
						}

					} else if (currentAmmoType == "BLUE") {
						if (newAmmoType == "RED"){
							combinationCat = 1; //PURPLE
						}
						else if (newAmmoType == "YELLOW"){
							combinationCat = 3; //GREEN
						}

					} else if (currentAmmoType == "YELLOW") {
						if (newAmmoType == "RED"){
							combinationCat = 2; //ORANGE
						}
						else if (newAmmoType == "BLUE"){
							combinationCat = 3; //GREEN
						}

					}
					//Debug.Log (combinationCat);
					Destroy(other.gameObject);
					CatCombinator(combinationCat);
				}

			}



			//other.gameObject.transform.position = backpackObject.transform.position;
			//other.gameObject.transform.SetParent(backpackObject.transform);
			// other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			// other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

			//other.gameObject.GetComponent<Collider>().isTrigger = true;

		}
	}
	void CatCombinator(int combinationType){

		switch(combinationType){
		case 1:
			foreach (Transform child in pack.transform) //delete all children in backpack
			{
				GameObject.Destroy(child.gameObject);
			}
			currentAmmoType = AmmoTypeScript.AmmoType.PURPLE.ToString(); //track current ammo as red
			Instantiate(purpleAmmo, pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack
			currentBullet = purpleBullet; //set current bullet type to red bullet
			currentPurpleAmmoCount = purpleAmmoCount;
			newAmmoType = null;
			break;
		case 2:
			foreach (Transform child in pack.transform) //delete all children in backpack
			{
				GameObject.Destroy(child.gameObject);
			}
			currentAmmoType = AmmoTypeScript.AmmoType.ORANGE.ToString(); //track current ammo as red
			Instantiate(orangeAmmo, pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack
			currentBullet = orangeBullet; //set current bullet type to red bullet
			currentOrangeAmmoCount = orangeAmmoCount;
			newAmmoType = null;
			break;
		case 3:
			foreach (Transform child in pack.transform) //delete all children in backpack
			{
				GameObject.Destroy(child.gameObject);
			}
			currentAmmoType = AmmoTypeScript.AmmoType.GREEN.ToString(); //track current ammo as red
			Instantiate(greenAmmo, pack.transform.position, pack.transform.rotation, pack.transform); //make new ammo object in backpack
			currentBullet = greenBullet; //set current bullet type to red bullet
			currentGreenAmmoCount = greenAmmoCount;
			newAmmoType = null;
			break;



		}
		warpTexture.GetComponent<suckingDisplay>().SendMessage("DisableVortex");

		warpZone.GetComponent<ObjectDetect>().ResetMultiplier(); //reset the gravity multiplier of the gun

		Invoke ("VacuumToEjectCooldown", 2);
		barrel.stateOfBarrel = BarrelCooldown.BarrelState.COMPLETE;
		stateOfGun = GunState.GUN;
		player.GetComponent<PlayerMovement> ().SetToWalkingSpeed ();

		Debug.Log("CurrentAmmo: " + currentAmmoType); //log the current ammo type

	}
}
