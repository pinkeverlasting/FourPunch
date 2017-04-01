using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWalkTo : MonoBehaviour {

    GameObject player;
    public Transform goal;
	UnityEngine.AI.NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        goal = player.GetComponent<Transform>();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = goal.position;
	}
}
