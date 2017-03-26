using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suckingDisplay : MonoBehaviour {
 
	private Renderer rend;

    public bool isExplosion;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			print ("Pressed");
			//rend.enabled = true;
		} else if (Input.GetKeyUp(KeyCode.Space)) {
			print ("Released");
			//rend.enabled = false;
		}
        if (isExplosion && gameObject.name == "GreenBullet")
        {
            rend.enabled = true;
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
