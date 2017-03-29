using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDeathScript : MonoBehaviour {

    private Transform pitRespawn;
	// Use this for initialization
	void Start () {
        pitRespawn = GameObject.Find("PitRespawn").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = pitRespawn.position;
        }
    }
}
