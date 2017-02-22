using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneThree : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			foreach (Collider collider in other.gameObject.GetComponents<Collider>())
			{

				collider.isTrigger = true;
				if (collider is SphereCollider) {
					SphereCollider zoneOne = (SphereCollider)collider;
					//Do some stuff with the box collider
					Debug.Log ("One");

				}
				if (collider is CapsuleCollider) {
					CapsuleCollider zoneTwo = (CapsuleCollider)collider;
					Debug.Log ("Two");
				}
			}
		}
	}

	public void OnTriggerExit (Collider otherExit)
	{
		//if (otherExit.gameObject.CompareTag ("Player"))
			//ChaseState ();
	}
}
