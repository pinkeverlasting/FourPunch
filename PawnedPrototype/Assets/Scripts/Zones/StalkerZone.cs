using UnityEngine;
using System.Collections;

public class StalkerZone : EnemyState {

	private readonly EnemyStatePattern enemy;


	public StalkerZone (EnemyStatePattern statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{

		enemy.distance = Vector3.Distance (enemy.transform.position, enemy.character.transform.position);


		if (enemy.distance >= 17.0f) {
			if (enemy.alive) {
				WanderState ();
			}
		} else {
			if (enemy.alive) {
				Stalk ();
			}
		}
	}

	public void OnTriggerEnter (Collider other)
	{
		/*if (other.gameObject.tag == "Player") {
			if (enemy.alive)
				ChaseState ();
		}*/
	}

	public void OnTriggerExit (Collider otherExit) {

	}

	public void WanderState()
	{
		enemy.move = true;
		enemy.currentState = enemy.wanderingState;
	}

	public void StalkerState()
	{
		Debug.Log ("Current State");
	}

	public void ChaseState()
	{
		enemy.move = true;
		enemy.currentState = enemy.chaseState;
	}


	void Stalk()
	{


		if (enemy.alive == true && enemy.seePlayer) { 
			enemy.characterPostition = new Vector3 (enemy.character.position.x, 
				enemy.transform.position.y, 
				enemy.character.position.z);
			enemy.transform.LookAt (enemy.characterPostition);
		} else {

			WanderState ();
		}

	}

}

//	//public CharacterController controller;
//	public Transform target;  //character
//	public Vector3 targetPostition;
//	public bool alive; 
//	// Use this for initialization
//	void Start () {
//		//controller = GetComponent<CharacterController> ();
//		alive = true;
//		target = GameObject.FindWithTag ("Player").transform;
//	}
//
//	// Update is called once per frame
//	void Update () {
//		if (alive) { 
//			targetPostition = new Vector3 (target.position.x, 
//				this.transform.position.y, 
//				target.position.z);
//			transform.LookAt (targetPostition);
//		}
//	}
//}