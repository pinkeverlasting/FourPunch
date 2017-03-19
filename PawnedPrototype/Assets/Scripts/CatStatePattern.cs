using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStatePattern : MonoBehaviour {

	public bool sucked; 
	public bool crouching;
	public float timeBetweenChange;     // seconds between the two states
	float timer;                         // Timer for change.

	//Movement State
	[HideInInspector] public Vector3 wayPoint = Vector3.zero;
	[HideInInspector] public Vector3 moveDirection; 
	[HideInInspector] public Vector3 target; 
	[HideInInspector] public Vector3 direction;

	//Crouch State 



	// Use this for initialization
	void Start () {
		sucked = false; 
		timeBetweenChange = Random.Range (7.0f, 12.0f);
		crouching = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(timer >= timeBetweenChange && !sucked)
		{
			if (crouching) {
				crouchingState ();
			} else {
				//walking ();
			}
		}
		
	}

	void crouchingState() {
		/*timeBetweenAttacks = Random.Range (7.0f, 12.0f);
		target = wayPoint;
		target.y = transform.position.y; 

		if (Vector3.Distance (transform.position, target) > 2) {
			targetTime -= Time.deltaTime;
			//Debug.Log ("Timer: " + targetTime);
			enemy.transform.LookAt (enemy.target);
			//direction = enemy.target - enemy.transform.position;
			enemy.direction = enemy.target - enemy.transform.position;
			enemy.direction = enemy.direction.normalized;
			enemy.GetComponent<Rigidbody> ().velocity = (enemy.transform.forward * 3f);
			//enemy.GetComponent<Rigidbody> ().AddForce(direction * 25f);
			//enemy.GetComponent<Rigidbody> ().AddForce (enemy.transform.forward * 15f, ForceMode.Force);
		} else {
			getwayPoint ();

		}*/

	}


}



