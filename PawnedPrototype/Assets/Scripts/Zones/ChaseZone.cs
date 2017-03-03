using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseZone : EnemyState {

	private readonly EnemyStatePattern enemy;

	//Raycast Vars 
	private float distanceBetween; 
	private RaycastHit hit;
	private Vector3 forward;


	public ChaseZone (EnemyStatePattern statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		/* Future Raycast Stuff I'm still fixing*/

		if (enemy.alive) {
			Chase ();
		}


	}

	public void OnTriggerEnter (Collider other)
	{
//		if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Mutant" ) {
//			WanderState ();
//			enemy.wanderingState.getwayPoint ();
//			Debug.Log ("HITWALL");
//
//		}
	}

	public void OnTriggerExit (Collider otherExit) {
			
	}


	public void WanderState()
	{
		enemy.currentlyChasing = false;
		enemy.move = true;
		enemy.chase = false;
		enemy.currentState = enemy.wanderingState;
	}

	public void StalkerState()
	{
		enemy.currentlyChasing = false;
		enemy.move = false;
		enemy.chase = false;
		enemy.currentState = enemy.stalkingState;
	}

	public void ChaseState()
	{
		enemy.currentState = enemy.chaseState;
	}
		


	void Chase() {

		enemy.currentlyChasing = true;


		if (enemy.seePlayer) {
			//get player position
			enemy.characterPostition = new Vector3 (enemy.character.position.x, 
				enemy.transform.position.y, 
				enemy.character.position.z);

			//keep chasing until 2 away from player
			if (Vector3.Distance (enemy.transform.position, enemy.characterPostition) > 2) {
				//look at player
				enemy.transform.LookAt (enemy.characterPostition);
				//direction = enemy.target - enemy.transform.position;

				//move!! 
				enemy.moveDirection = enemy.characterPostition - enemy.transform.position;
				enemy.moveDirection = enemy.moveDirection.normalized;
				enemy.GetComponent<Rigidbody> ().velocity = (enemy.transform.forward * 6f);
			}
		} else { 

			WanderState ();
		}
				
	}

}
