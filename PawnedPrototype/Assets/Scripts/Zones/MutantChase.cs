using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantChase : EnemyState {

	private readonly EnemyStatePattern enemy;

	//Raycast Vars 
	private bool chase;
	private float distanceBetween; 
	private RaycastHit hit;
	private Vector3 forward;


	public MutantChase (EnemyStatePattern statePatternEnemy)
	{
		enemy = statePatternEnemy;
		chase = false;
	}

	public void UpdateState()
	{
		/* Future Raycast Stuff I'm still fixing
		forward = enemy.eyes.transform.TransformDirection (Vector3.forward) * enemy.sightRange;
		Debug.DrawRay (enemy.eyes.transform.position, forward, Color.green);

		if (!chase) {
			Search ();
		}
		*/

		//if (chase) {
		if (enemy.alive) {
			Chase ();
		}
		//}
			
	}

	public void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Cannot Enter Zone");
	}

	public void OnTriggerExit (Collider otherExit) {

		if (otherExit.gameObject.tag == "Player") {
			if (enemy.alive)
					StalkerState ();
		}
	}

	public void WanderState()
	{
		enemy.move = true;
		//chase = false;
		enemy.currentState = enemy.wanderingState;
	}

	public void StalkerState()
	{
		enemy.move = false;
		//chase = false;
		enemy.currentState = enemy.stalkingState;
	}

	public void ChaseState()
	{
		enemy.currentState = enemy.chaseState;
	}

	void Search()
	{
		//TBA: When player is in range AND is line in slight 

		//if it's in range and see player
		/*if (Physics.Raycast (enemy.eyes.transform.position,(forward), out hit) && hit.collider.tag == "Player") {
			distanceBetween = hit.distance;
			chase = true; 

		}
		else
		{
			WanderState();
		}*/
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
