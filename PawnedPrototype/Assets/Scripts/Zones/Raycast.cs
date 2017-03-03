using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

	//Raycast
	public RaycastHit hit;
	public Vector3 forward; 
	public float sightRange = 20f;
	public float theDistance;

	private EnemyStatePattern enemy;
	private Transform myTransform;
	public GameObject playerCharacter; 
	private Vector3 characterPosition;

	// Use this for initialization
	void Start () {
		enemy = transform.parent.GetComponent<EnemyStatePattern>();
		myTransform = transform.parent;
		playerCharacter = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Search ();
	
	}

	void Search() {

		//forward = transform.TransformDirection (Vector3.forward) * 15;  //old forward raycast
		characterPosition = playerCharacter.transform.position;
		//Debug.Log (characterPosition);
		Debug.DrawRay(transform.position, characterPosition - transform.position, Color.green);

		if (Physics.Raycast (transform.position, characterPosition - transform.position, out hit) &&  hit.transform.tag == "Player") {
			theDistance = hit.distance;
			enemy.seePlayer = true;
			//Debug.Log (theDistance + " " + hit.transform.name);
		} else {
			enemy.seePlayer = false;
			//Debug.Log (theDistance + " " + hit.transform.name);
		}
	}
}
