using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampCharacterDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//on mouse click and if it's in gun mode: check current cat type, eject it out, switch mode to eject (later will need cool down to switch eject back to vacuum mode)
	}

    private void OnTriggerEnter(Collider col) //when it hits a ramp or stairs turn gravity off. 
    {
        //Debug.Log(col.gameObject);
        if (col.gameObject.tag == "Player") //if the object is a player
        {
            Debug.Log(col.gameObject);
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
            Debug.Log(col.gameObject);
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
