using UnityEngine;
using System.Collections;

public class EnemyStatePattern : MonoBehaviour 
{


	//Enemy Wander Vars
	[HideInInspector] public Vector3 wayPoint = Vector3.zero;
	[HideInInspector] public Vector3 moveDirection; 
	[HideInInspector] public Vector3 target; 
	[HideInInspector] public float speedWandering; 
	[HideInInspector] public float distance; 
	public Vector3 myLastPosition; 
	public int range = 15;
	public bool move = true;
	public bool seePlayer;

	//New Enemy Wander Vars
	public Vector3 direction;
	public Vector3 lastPosition;
	public bool hitWall; 

	//Enemy Stalker Vars
	public Transform character;  //put character gameobject here
	public Vector3 characterPostition;
	public bool alive; 

	//Enemy Chase Vars
	public bool chase;
	public bool currentlyChasing;
	public GameObject players;
	public Vector3 offset = new Vector3 (0,.5f,0);
	[HideInInspector] public float speedChasing;


	//Script & States 
	[HideInInspector] public EnemyState currentState;
	[HideInInspector] public WanderZone wanderingState;
	[HideInInspector] public StalkerZone stalkingState;
	[HideInInspector] public ChaseZone chaseState;


	private void Awake()
	{
		chaseState = new ChaseZone (this);
		wanderingState = new WanderZone (this);
		stalkingState = new StalkerZone (this);
		character = players.transform;

		speedWandering = 2.0f * Time.deltaTime;
		speedChasing = 5.0f * Time.deltaTime;
		myLastPosition = Vector3.zero;
		currentlyChasing = false;
		seePlayer = false;
		distance = 0;
		alive = true;
		chase = false;
		 
	}

	// Use this for initialization
	void Start () 
	{	wanderingState.getwayPoint ();
		currentState = wanderingState;
	}

	// Update is called once per frame
	void Update () 
	{
		if (alive) {
			currentState.UpdateState ();
		}
	}

	

	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter (other);

	}


	private void OnTriggerExit(Collider otherExit)
	{
		currentState.OnTriggerExit (otherExit);
	}
		
}