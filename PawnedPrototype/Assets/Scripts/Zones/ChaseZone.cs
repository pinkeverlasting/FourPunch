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
		Debug.Log ("Cannot Enter Zone");
	}

	public void OnTriggerExit (Collider otherExit) {
				Debug.Log ("HEY");
				if (otherExit.gameObject.tag == "Player") {
					if (enemy.alive)
						StalkerState ();
				}
			
		}


	public void WanderState()
	{
		enemy.move = true;
		enemy.chase = false;
		enemy.currentState = enemy.wanderingState;
	}

	public void StalkerState()
	{
		enemy.move = false;
		enemy.chase = false;
		enemy.currentState = enemy.stalkingState;
	}

	public void ChaseState()
	{
		enemy.currentState = enemy.chaseState;
	}


	void Chase() {

			//get player's position as a Vector 3
			enemy.characterPostition = new Vector3 (enemy.character.position.x, 
				enemy.transform.position.y, 
				enemy.character.position.z);

			//looks at player and chases 
			enemy.moveDirection = enemy.characterPostition - enemy.transform.position;

			// if reached the player, stop
			if (enemy.moveDirection.magnitude < 2) {
				enemy.moveDirection = Vector3.zero;
				enemy.transform.position = enemy.transform.position;

			} else {
				//else chase the player
				enemy.transform.position = Vector3.MoveTowards (enemy.transform.position, enemy.characterPostition, enemy.speedChasing);
				enemy.transform.LookAt (enemy.characterPostition);

			}

	}

}
