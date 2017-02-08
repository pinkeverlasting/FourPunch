using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHit : MonoBehaviour {
	private EnemyWander wander;

    private float force;
	// Use this for initialization
	void Start () {
		wander = gameObject.GetComponent<EnemyWander>();
        force = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && wander.move == true)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && wander.move == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnCollisionEnter (Collision col)
	{ 

		if (col.gameObject.GetComponent<BulletDeletion>() != null && wander.move == true)
		{

            //GetComponent<Rigidbody>().isKinematic = false;
            wander.move = false;


             //Vector3 dir = col.contacts[0].point - transform.position;
            //Vector3 dir = transform.position - col.gameObject.transform.position;
            //dir = -dir.normalized;
           // Debug.Log(dir);
           // this.GetComponent<Rigidbody>().AddForce(dir*force);

            Destroy(col.gameObject);

            this.GetComponent<Rigidbody>().AddForce(Vector3.forward*20);
            //GetComponent<Rigidbody>().isKinematic = false;
        }
	}
}
