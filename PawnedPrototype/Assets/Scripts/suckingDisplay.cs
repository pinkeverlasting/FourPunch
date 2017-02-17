using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suckingDisplay : MonoBehaviour {
 
	private Renderer rend;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (1)) {
			print ("Pressed");
			//rend.enabled = true;
		} else if (Input.GetMouseButtonUp (1)) {
			print ("Released");
			//rend.enabled = false;
		}

	}
    void ShowVortex()
    {
        rend.enabled = true;
    }

    void DisableVortex()
    {
       rend.enabled = false;
    }
		
}
