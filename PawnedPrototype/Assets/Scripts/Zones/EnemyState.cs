using UnityEngine;
using System.Collections;

public interface EnemyState {
	//My Controller for Changing Functions and States 

	void UpdateState(); 

	void OnTriggerEnter (Collider other);

	void OnTriggerExit (Collider otherExit);

	void WanderState();

	void StalkerState();

	void ChaseState();
}

