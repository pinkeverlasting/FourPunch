using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlightEyes : MonoBehaviour {
	private EnemyStatePattern enemy;

	void Start() {

		enemy = transform.parent.GetComponent<EnemyStatePattern>();
		enemy.chase = false;

	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "Player") { 
			enemy.chase = true;
			//Debug.Log (enemy.chase);
		}
	}

	void OnTriggerEnter (Collider other) {
		if ( (other.gameObject.tag == "test" || other.gameObject.tag == "Wall") && enemy.chaseState.alwaysChase == false ) { 
			
			enemy.currentState.WanderState ();
			enemy.wanderingState.getwayPoint ();
			//Debug.Log (enemy.chase);
		}
	}
}
