using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseOnWake : MonoBehaviour {

	public Transform character;  //put character gameobject here
	public Vector3 characterPostition;
	public GameObject players;
	[HideInInspector] public Vector3 moveDirection; 


	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectWithTag ("Player");
		character = players.transform;
	}
	
	// Update is called once per frame
	void Update () {

		//get player position
		characterPostition = new Vector3 (character.position.x, 
			transform.position.y, character.position.z);

		//keep chasing until 2 away from player
		if (Vector3.Distance (transform.position,characterPostition) > 0) {
			//look at player
			transform.LookAt (characterPostition);
			//direction = enemy.target - enemy.transform.position;

			//move!! 
			moveDirection = characterPostition - transform.position;
			moveDirection = moveDirection.normalized;
			GetComponent<Rigidbody> ().velocity = (transform.forward * 6f);
		}
	}
}
