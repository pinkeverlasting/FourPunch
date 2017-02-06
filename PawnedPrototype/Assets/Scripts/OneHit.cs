using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHit : MonoBehaviour {
	private EnemyWander wander;
	// Use this for initialization
	void Start () {
		wander = gameObject.GetComponent<EnemyWander>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter (Collision col)
	{ 

		if (col.gameObject.GetComponent<BulletDeletion>() != null)
		{
			wander.move = false; 
			GetComponent<Rigidbody>().isKinematic = false;
		}
	}
}
