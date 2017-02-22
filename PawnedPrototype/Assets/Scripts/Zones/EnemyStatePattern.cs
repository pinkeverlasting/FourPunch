﻿using UnityEngine;
using System.Collections;

public class EnemyStatePattern : MonoBehaviour 
{


	//Enemy Wander Vars
	[HideInInspector] public Vector3 wayPoint = Vector3.zero;
	[HideInInspector] public Vector3 moveDirection; 
	[HideInInspector] public Vector3 target; 
	[HideInInspector] public float speedWandering; 
	[HideInInspector] public float distance; 
	public int range = 15;
	public bool move = true;

	//Enemy Stalker Vars
	public Transform character;  //put character gameobject here
	public Vector3 characterPostition;
	public bool alive; 

	//Enemy Chase Vars
	public float sightRange = 20f;
	public Transform eyes;
	public Vector3 offset = new Vector3 (0,.5f,0);
	[HideInInspector] public float speedChasing;


	//Script & States 
	[HideInInspector] public EnemyState currentState;
	[HideInInspector] public EnemyWander wanderingState;
	[HideInInspector] public MutantStalker stalkingState;
	[HideInInspector] public MutantChase chaseState;


	private void Awake()
	{
		chaseState = new MutantChase (this);
		wanderingState = new EnemyWander (this);
		stalkingState = new MutantStalker (this);

		speedWandering = 2.0f * Time.deltaTime;
		speedChasing = 5.0f * Time.deltaTime;
		distance = 0;
		alive = true;
		 
		//navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	// Use this for initialization
	void Start () 
	{	wanderingState.getwayPoint ();
		currentState = wanderingState;
	}

	// Update is called once per frame
	void Update () 
	{
		if (alive) 
		currentState.UpdateState ();
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