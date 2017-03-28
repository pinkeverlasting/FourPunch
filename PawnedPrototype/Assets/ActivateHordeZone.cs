using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHordeZone : MonoBehaviour {

   public GameObject hordeObjects;
   public GameObject playerCamera;
   public GameObject player;

    GameObject hordeCamera;
	// Use this for initialization
	void Start () {
        hordeObjects.SetActive(false);
        hordeCamera = GameObject.Find("HordeCamera");
        hordeCamera.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerCamera.SetActive(false); //turn player camera on
            player.GetComponent<PlayerMovement>().canMove = false; //player can move

            hordeObjects.SetActive(true);
            hordeCamera.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }
}
