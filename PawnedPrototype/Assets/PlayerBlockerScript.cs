using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Mutant")
        {
            Debug.Log("Executing");
            //Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            Physics.IgnoreLayerCollision(8,9,true);
        }
    }
}
