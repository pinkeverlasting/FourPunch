using UnityEngine;
using System.Collections;

public class WanderZone : EnemyState {

	private readonly EnemyStatePattern enemy;


	public WanderZone (EnemyStatePattern statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{

		if (enemy.alive) 
			Wander ();
	}


	public void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {	
			if (enemy.alive && enemy.chase)
				ChaseState ();  //Enter to Zone One which is Chasing Zone\
		}

	}
		

	public void OnTriggerExit (Collider otherExit)
	{

	}

	public void WanderState()
	{
		Debug.Log ("Can't transition to same state");
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
			enemy.target.y = 1.06f; 
			enemy.moveDirection = enemy.target - enemy.transform.position;
			if (enemy.moveDirection.magnitude < 1) {
				enemy.moveDirection = Vector3.zero;
				getwayPoint ();
			} else {
				//moveTime = Time.deltaTime * Speed;
				enemy.transform.position = Vector3.MoveTowards (enemy.transform.position, enemy.target, enemy.speedWandering);
				enemy.transform.LookAt (enemy.target);
				//transform.position = Vector3.Lerp(currentWaypoint, target, fraction);

			}
		}

	}

	public void getwayPoint() {
		//currentWaypoint = transform.position; 
		//wayPoint = Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range), 1, Random.Range(transform.position.z - Range, transform.position.z + Range));

		// wayPoint = Random.insideUnitSphere * 20f;

		enemy.wayPoint = new Vector3(Random.Range(enemy.transform.position.x - enemy.range, enemy.transform.position.x + enemy.range),
			1, Random.Range(enemy.transform.position.z - enemy.range, enemy.transform.position.z + enemy.range));

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

