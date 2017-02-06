using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuantStalker : MonoBehaviour {

	//public CharacterController controller;
	public Transform target;
	public Vector3 targetPostition;
	public bool alive; 
	// Use this for initialization
	void Start () {
		//controller = GetComponent<CharacterController> ();
		alive = true;
		target = GameObject.FindWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		if (alive) { 
			targetPostition = new Vector3 (target.position.x, 
				this.transform.position.y, 
				target.position.z);
			transform.LookAt (targetPostition);
		}
	}
}