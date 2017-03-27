using UnityEngine;
using System.Collections;

public class WanderZone : EnemyState {

	private readonly EnemyStatePattern enemy;
	public float targetTime = 30.0f;

    


	public WanderZone (EnemyStatePattern statePatternEnemy)
	{
		enemy = statePatternEnemy;
		enemy.GetComponent<Rigidbody> ().freezeRotation = true;
		enemy.hitWall = false;
	}

	public void UpdateState()
	{

		if (enemy.alive) {
			Wander ();
		}
			
	}
		
	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Mutant") {
			enemy.wanderingState.getwayPoint ();

		}
	}
		

	public void OnTriggerExit (Collider otherExit)
	{

	}

	public void WanderState()
	{
		
	}

	public void ChaseState()
	{
		
			enemy.currentState = enemy.chaseState;

	}

	public void StalkerState()
	{
		
			enemy.move = false;
			enemy.currentState = enemy.stalkingState;
			Debug.Log ("RUNSTALKER");

	}

	void Wander ()
	{
		if (enemy.move) {


			enemy.target = enemy.wayPoint;
			enemy.target.y = enemy.transform.position.y;
				//enemy.transform.position.y; 

			if (Vector3.Distance (enemy.transform.position, enemy.target) > 2) {
				targetTime -= Time.deltaTime;
				//Debug.Log ("Timer: " + targetTime);
				enemy.transform.LookAt (enemy.target);
				//direction = enemy.target - enemy.transform.position;
				enemy.direction = enemy.target - enemy.transform.position;
				enemy.direction = enemy.direction.normalized;
				enemy.GetComponent<Rigidbody> ().velocity = (enemy.transform.forward * 3f);
				//enemy.GetComponent<Rigidbody> ().AddForce(direction * 25f);
				//enemy.GetComponent<Rigidbody> ().AddForce (enemy.transform.forward * 15f, ForceMode.Force);
			} else {
				getwayPoint ();

			}

			if (targetTime <= 0.0f)
			{
				getwayPoint ();
				//time for preventing AI from being Stuck
				targetTime = 30.0f;
			}
		
		} 

		/*else if (!enemy.move && enemy.hitWall) {
			//BOUNCE BACK
			enemy.lastPosition = enemy.transform.position - enemy.GetComponent<Rigidbody> ().velocity; 

			if (Vector3.Distance (enemy.transform.position, enemy.lastPosition) > 5f) {
				enemy.GetComponent<Rigidbody> ().velocity = -(enemy.transform.forward * 5f);
			} else {
				getwayPoint ();
				enemy.hitWall = false;
				enemy.move = true;

			}
			/*enemy.lastPosition = enemy.transform.position - enemy.GetComponent<Rigidbody> ().velocity; 
			enemy.GetComponent<Rigidbody> ().AddForce(enemy.lastPosition * 5f);
			if (Vector3.Distance (enemy.transform.position, enemy.lastPosition) > 0.5f) {
				getwayPoint ();
				enemy.hitWall = false;
			}

		}*/

	}

	public void getwayPoint() {
        //currentWaypoint = transform.position; 
        //wayPoint = Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range), 1, Random.Range(transform.position.z - Range, transform.position.z + Range));

        // wayPoint = Random.insideUnitSphere * 20f;

        /*enemy.wayPoint = new Vector3(Random.Range(enemy.transform.position.x - enemy.range, enemy.transform.position.x + enemy.range),
			1, Random.Range(enemy.transform.position.z - enemy.range, enemy.transform.position.z + enemy.range));*/
        enemy.wayPoint = new Vector3(Random.Range(enemy.transform.position.x - enemy.range, enemy.transform.position.x + enemy.range),
			enemy.startingHeight, Random.Range(enemy.transform.position.z - enemy.range, enemy.transform.position.z + enemy.range));

    }

}


//	/*public CharacterController controller;
//	public Vector3 wayPoint;
//	public float speed = 5.0f;
//	public float offset;
//	public Vector3 target; 
//	public Vector3 moveDirection; 
//	*/
//	public float Speed = 0.1f;
//	public Vector3 wayPoint = Vector3.zero; 
//	public Vector3 target; 
//	public Vector3 moveDirection;
//    //private Vector3 currentWaypoint; 
//    private int range = 15;
//
//	private float moveTime = 0.0f; 
//	public bool move; 
//
//	// Use this for initialization
//	void Start () {
//		move = true;
//       // wayPoint = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range),
//          //  1, Random.Range(transform.position.z - range, transform.position.z + range));
//          getwayPoint (); 
//
//    }
//
//    // Update is called once per frame
//    void Update () {
//
//		if (move) {
//
//			target = wayPoint;
//			target.y = 1.06f; 
//			moveDirection = target - transform.position;
//			if (moveDirection.magnitude < 1) {
//				moveDirection = Vector3.zero;
//				getwayPoint ();
//			} else {
//                //moveTime = Time.deltaTime * Speed;
//                transform.position = Vector3.MoveTowards(transform.position, target, 4.0f * Time.deltaTime);
//                transform.LookAt (target);
//				//transform.position = Vector3.Lerp(currentWaypoint, target, fraction);
//				
//			}
//		}

//if (enemy.move) {
//
//	enemy.target = enemy.wayPoint;
//	enemy.target.y = 1.06f; 
//	enemy.moveDirection = enemy.target - enemy.transform.position;
//	if (enemy.moveDirection.magnitude < 1) {
//		enemy.moveDirection = Vector3.zero;
//		getwayPoint ();
//	} else {
//		//moveTime = Time.deltaTime * Speed;
//		enemy.transform.position = Vector3.MoveTowards (enemy.transform.position, enemy.target, enemy.speedWandering);
//		enemy.transform.LookAt (enemy.target);
//		//transform.position = Vector3.Lerp(currentWaypoint, target, fraction);
//
//	}
//}
//			
//	}
//
//	private void OnCollisionEnter (Collision col)
//	{
//        //Debug.Log(col.gameObject.tag == "Mutant");
//		if (col.gameObject.tag == "Mutant" || col.gameObject.tag == "Player" || col.gameObject.tag == "test" ) {
//           
//            //getwayPoint ();
//            //Destroy(this.gameObject);
//		}
//       // Debug.Log(col.gameObject);
//        //Destroy(this.gameObject);
//
//    }
//
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "Mutant" || other.gameObject.tag == "test")
//        {
//           // Debug.Log("collision!");
//            getwayPoint();
//        }
//    }
//
//    /*void OnControllerColliderHit(ControllerColliderHit hit) {
//		if (hit.gameObject.tag == "Player" || hit.gameObject.tag == "Mutant" ) {
//			getwayPoint ();
//		}
//	}*/
//
//    void getwayPoint() {
//        //currentWaypoint = transform.position; 
//        //wayPoint = Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range), 1, Random.Range(transform.position.z - Range, transform.position.z + Range));
//
//       // wayPoint = Random.insideUnitSphere * 20f;
//
//        wayPoint = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range),
//            1, Random.Range(transform.position.z - range, transform.position.z + range));
//
//	}
//
//}
//

