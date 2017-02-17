using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invis : MonoBehaviour {
	public GameObject building; 
	private Color color;
	private Renderer rend;
	private bool invisObject;
	// Use this for initialization
	void Start () {
		rend = building.GetComponent<Renderer>();
		invisObject = false;
		color = rend.material.color;
	}
	
	// Update is called once per frame
	void Update () {

		if ( color.a <= 1.0f && invisObject == false) {
			color = rend.material.color;
			color.a += 0.1f;
			rend.material.SetColor("_Color", color);
		}
		
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			invisObject = true;
			color = rend.material.color;
			color.a -= 0.1f;
			rend.material.SetColor("_Color", color);
		}
	}

	void OnTriggerExit(Collider other) { 
		if (other.gameObject.tag == "Player") {
				invisObject = false; 

			}
		}
}
