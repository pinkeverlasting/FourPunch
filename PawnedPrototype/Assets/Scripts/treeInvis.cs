using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeInvis : MonoBehaviour {

	public GameObject building; 
	private Color color;
	private Color color2;
	private Renderer rend;
	private bool invisObject;
	private Material[] myMaterials;

	// Use this for initialization
	void Start () {

		building = this.transform.parent.gameObject;
		rend = building.GetComponent<Renderer>();
		invisObject = false;
		color = rend.materials[1].color; 
		color2 = rend.materials[0].color; 

	}

	// Update is called once per frame
	void Update () {

		if ( color.a <= 1.0f && invisObject == false) {
			color = rend.materials[1].color; 
			color2 = rend.materials[0].color; 
			color.a += 0.3f;
			color2.a += 0.3f;
			rend.materials[1].SetColor("_Color", color);
			rend.materials[0].SetColor("_Color", color2);
		}

		if (color.a == 1.0f) {
			rend.castShadows = true;
		}

	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			//Debug.Log ("PLAYERSADSFASDF");
			if (color.a >= 0.1f) {
				rend.castShadows = false;
				invisObject = true;
				color = rend.materials [1].color;
				color2 = rend.materials [0].color;
				color.a -= 0.1f;
				color2.a -= 0.1f;
				rend.materials [1].SetColor ("_Color", color);
				rend.materials [0].SetColor ("_Color", color2);
			}
		}
	}

	void OnTriggerExit(Collider other) { 
		if (other.gameObject.tag == "Player") {
			invisObject = false; 

		}
	}
}
