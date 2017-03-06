using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
