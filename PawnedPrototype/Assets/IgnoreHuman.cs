using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreHuman : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider>(), GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
