using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeDet : MonoBehaviour {

	public EquitmentDialoge detect;
	// Use this for initialization
	void Start () {
		detect = GameObject.Find ("TheGuy").GetComponent<EquitmentDialoge> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") { //if player approaches, show text
			detect.range = true;
		}
	}
}
