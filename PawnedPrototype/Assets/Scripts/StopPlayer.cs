using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour {

	public GameObject dialText;
	public EnterNozzleDetect equitment;
	public GameObject block;

	// Use this for initialization
	void Start () {
		dialText.SetActive(false);
		equitment = GameObject.Find("NozzleTrigger").GetComponent<EnterNozzleDetect> ();
		block.SetActive(false);
	}

	// Update is called once per frame
	void Update () {


	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player") //if player approaches, show text
		{
			if (equitment.hasEquipment == false) {
				dialText.SetActive (true);
				block.SetActive (true);
				Invoke ("StopDial", 15);
			} else if (equitment.hasEquipment == true) {
				dialText.SetActive (false);
				block.SetActive (false);
			}
		}
	}
	private void OnTriggerExit(Collider other) //turns off text if you leave
	{
		if (other.gameObject.tag == "Player")
		{
			dialText.SetActive(false);

		}
	}
	private void StopDial() //turns off text if you stay too long
	{
		dialText.SetActive(false);
	}
}
