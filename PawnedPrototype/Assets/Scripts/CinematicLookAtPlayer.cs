using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicLookAtPlayer : MonoBehaviour {

    public bool canLook;

    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (canLook)
        {
            transform.LookAt(player.transform);
        }
	}
}
