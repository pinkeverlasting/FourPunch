using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStatePattern : MonoBehaviour {

	//Movement State
	[HideInInspector] public Vector3 wayPoint = Vector3.zero;
	[HideInInspector] public Vector3 moveDirection; 
	[HideInInspector] public Vector3 target; 
	[HideInInspector] public Vector3 direction;

	//Crouch State 



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
