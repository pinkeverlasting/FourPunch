using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlightEyes : MonoBehaviour {
	private EnemyStatePattern enemy;

	void Start() {

		enemy = transform.parent.GetComponent<EnemyStatePattern>();
		enemy.chase = false;

	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") { 
			enemy.chase = true;
			Debug.Log (enemy.chase);
		}
	}
}
