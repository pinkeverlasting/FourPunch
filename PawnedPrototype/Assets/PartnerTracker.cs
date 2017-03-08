using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerTracker : MonoBehaviour {

    public GameObject passObject;
    public GameObject partnerMutant;

	// Use this for initialization
	void Start () {
        Physics.IgnoreCollision(passObject.GetComponent<Collider>(), this.GetComponent<Collider>());
    }
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<EnemyStatePattern>().enabled == false)
        {
            //Destroy(this.gameObject);
            if (partnerMutant.GetComponent<EnemyStatePattern>().enabled == false)
            {
                //Physics.IgnoreCollision(passObject.GetComponent<Collider>(), this.GetComponent<Collider>());
               // passObject.GetComponent<Collider>();
                passObject.transform.position = this.transform.position;
                this.GetComponent<PartnerTracker>().enabled = false;
            }
            else
            {
                this.GetComponent<PartnerTracker>().enabled = false;
            }

        }
		
	}
}
