using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : MonoBehaviour {

	public CharacterController controller;
	public Vector3 wayPoint;
	public float speed = 5.0f;
	public float offset;
	public Vector3 target; 
	public Vector3 moveDirection; 



	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		getwayPoint (); 

	}

	// Update is called once per frame
	void Update () {
		target = wayPoint; 
		target.y = 1.06f;		//transform.position.y; 
		moveDirection = target - transform.position;
		if (moveDirection.magnitude < 1) {
			//transform.position = target; // force character to waypoint position
			moveDirection = Vector3.zero;
			getwayPoint ();
		} else {
			transform.LookAt(target);
			controller.Move (moveDirection.normalized * speed * Time.deltaTime);
		}



	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Player" || hit.gameObject.tag == "Mutant" ) {
			getwayPoint ();
		}
	}

	void getwayPoint() {
		wayPoint= Random.insideUnitSphere * 10f;
	}

}

