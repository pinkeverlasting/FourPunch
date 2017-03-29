using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStatePattern : MonoBehaviour {

	public bool sucked; 
	public bool crouching;
	public float timeBetweenChange;     // seconds between the two states
	float timer;                         // Timer for change.
	float distToGround;  //check if grounded 
	public Raycast hit; 

	//Movement State
	public Vector3 wayPoint = Vector3.zero;
	public Vector3 moveDirection; 
	[HideInInspector] public Vector3 target; 
	[HideInInspector] public Vector3 direction;
	public Transform character;  //put character gameobject here
	public float startingHeight;
	public float targetTime = 5.0f;
	public int range = 15;
	public bool first; 

	//Crouch State 



	// Use this for initialization
	void Start () {
		sucked = false;
		first = false;
		distToGround = GetComponent<Collider>().bounds.extents.y;
		timeBetweenChange = Random.Range (7.0f, 12.0f);
		crouching = false;
		character = this.transform;
		startingHeight = character.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;

		if (IsGrounded () == true) {
			Invoke ("getwayPoint", 5);
		} else {

			roll ();
		}

		if (first == true && IsGrounded() == true) {

			if (!sucked && first) {
				if (crouching) {
					crouchingState ();

				} else {
					walking ();

				}

			}

			if (timer >= timeBetweenChange && !sucked) {
				if (crouching) {
					crouching = false;
					timeBetweenChange = Random.Range (7.0f, 12.0f);
					timer = 0;
				} else {
					crouching = true;
					timeBetweenChange = Random.Range (3.0f, 7.0f);
					timer = 0;
				}
			}

		}
		
	}

	private void roll() {
		transform.Rotate(Vector3.right, 40f * Time.deltaTime);
	}

	private bool IsGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}

	void walking() {

		target = wayPoint;
		target.y = transform.position.y; 

		if (Vector3.Distance (transform.position, target) > 2) {
			targetTime -= Time.deltaTime;
			transform.LookAt (target);
			direction = target - transform.position;
			direction = direction.normalized;
			GetComponent<Rigidbody> ().velocity = (transform.forward * 3f);
		} else {
			getwayPoint ();

		}

		if (targetTime <= 0.0f)
		{
			getwayPoint ();
			//time for preventing AI from being Stuck
			targetTime = 5.0f;
		}

	}

	void crouchingState () {

		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
	}


	void getwayPoint() {
		first = true;
		wayPoint = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range),
		startingHeight, Random.Range(transform.position.z - range, transform.position.z + range));
	}


	void OnCollisionEnter(Collision collision) {

		if (!crouching) {
			getwayPoint ();
		}
			
	}

	void onTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Wall") {
			Debug.Log ("CatWall");
			getwayPoint ();
		}

	}

}



