using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampCharacterDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col) //when it hits a ramp or stairs turn gravity off. 
    {
        if (col.gameObject.tag == "Player") //if the object is a player
        {
            //Debug.Log(col.gameObject);
            col.gameObject.GetComponent<PlayerMovement>().gravity = -1; //set to low gravity

        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player") //if that object is a player
        {
            col.gameObject.GetComponent<PlayerMovement>().ResetGravity(); //call the reset gravity function of player.

        }
    }

    private void OnCollisionEnter(Collision col) //if object collides with ramp
    {
        if (col.gameObject.tag == "Player") //if the object is a player
        {
            //Debug.Log(col.gameObject);
            col.gameObject.GetComponent<PlayerMovement>().gravity = -1; //set to low gravity

        }
    }

    private void OnCollisionExit(Collision col) //if object stops colliding with ramp
    {
        if (col.gameObject.tag == "Player") //if that object is a player
        {
            col.gameObject.GetComponent<PlayerMovement>().ResetGravity(); //call the reset gravity function of player.

        }
    }
}
