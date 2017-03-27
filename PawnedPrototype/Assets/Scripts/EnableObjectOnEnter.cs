using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectOnEnter : MonoBehaviour {

    public GameObject objectToEnable;

    public GameObject cinematicCamera;
    public GameObject playerCamera;

    private GameObject player;
    // Use this for initialization
    void Start () {
        objectToEnable.SetActive(false);
        cinematicCamera.SetActive(false);
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") //if player enters the gate trigger
        {
            objectToEnable.SetActive(true); //enable the gate


            cinematicCamera.SetActive(true); //turn on the cinematic camera
            playerCamera.SetActive(false); //turn off player camera
            player.GetComponent<PlayerMovement>().canMove = false; //don't let player move

            this.gameObject.SetActive(false);
        }
    }
}
