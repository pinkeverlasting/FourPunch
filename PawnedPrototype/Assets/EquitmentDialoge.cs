using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquitmentDialoge : MonoBehaviour {

	public GameObject dialText;
	public GameObject dialText2;
	public GameObject dialText3;
	public EnterNozzleDetect player;
	public GameObject barrier; 
	public bool range;

	// Use this for initialization
	void Start () {
		dialText.SetActive(false);
		dialText2.SetActive(false);
		dialText3.SetActive(false);
		barrier.SetActive (true);
		range = false;
	}

	// Update is called once per frame
	void Update () {

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !player.hasEquipment) { //if player approaches, show text
			dialText.SetActive (true);
			Invoke ("StopDial", 15);
		} else if (other.gameObject.tag == "Player" && !range && player.hasEquipment) {
			dialText2.SetActive (true);
			Invoke ("StopDial", 15);
		} else if (player.hasEquipment && range) {
			dialText3.SetActive(true);
			barrier.SetActive (false);
		}
	}
	private void OnTriggerExit(Collider other) //turns off text if you leave
	{
		if (other.gameObject.tag == "Player")
		{
			dialText.SetActive(false);
			dialText2.SetActive(false);
			dialText3.SetActive(false);

		}
	}
	private void StopDial() //turns off text if you stay too long
	{
		dialText.SetActive(false);
		dialText2.SetActive(false);
		dialText3.SetActive(false);
	}
}