using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHit : MonoBehaviour {
	private EnemyStatePattern wander;

    private float force;
    private GameObject mutantObject;
    // Use this for initialization
    void Start () {
        mutantObject = transform.parent.gameObject;
        //wander = gameObject.GetComponent<EnemyStatePattern>();
        wander = mutantObject.GetComponent<EnemyStatePattern>();
        force = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (wander.move == false)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }*/
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && wander.alive == true)
		{
            if (other.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.RED)
            {
                Debug.Log("RED HAS COLLIDED");
                mutantObject.GetComponent<Rigidbody>().freezeRotation = false;

                // this.GetComponent<Rigidbody>().isKinematic = false;
                mutantObject.GetComponent<EnemyStatePattern>().enabled = false;
                //this.GetComponent<Rigidbody>().isKinematic = false;
                mutantObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);
                wander.alive = false;
                //look.alive = false;
                //wander.move = false;
                //wander.GetComponent<Rigidbody>().freezeRotation = false;
                //this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);

            }
            if (other.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.ORANGE)
            { 

                    mutantObject.GetComponent<Rigidbody>().freezeRotation = false;

                    // this.GetComponent<Rigidbody>().isKinematic = false;
                    mutantObject.GetComponent<EnemyStatePattern>().enabled = false;
                    //this.GetComponent<Rigidbody>().isKinematic = false;
                    mutantObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);
                   // wander.alive = false;
                //look.alive = false;

            }
            // wander.move = false;
            //wander.alive = false;
            // wander.GetComponent<Rigidbody>().freezeRotation = false;
            //this.GetComponent<EnemyStatePattern>().enabled = false;

            //this.GetComponent<EnemyStatePattern>().enabled = false;
            //GetComponent<Rigidbody>().isKinematic = false;
        }
       
        
       
        
    }

	private void OnTriggerExit(Collider other)
	{
		/*if (other.gameObject.tag == "Bullet" && wander.move == true)
		{
			//GetComponent<Rigidbody>().isKinematic = true;
		}*/
	}
    private void OnCollisionEnter (Collision col)
	{
       /* if (col.gameObject.tag == "Bullet" && wander.alive == true)
        {
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.RED)
            {
                Debug.Log("RED HAS COLLIDED");
                wander.move = false;
                wander.GetComponent<Rigidbody>().freezeRotation = false;
                this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);

            }
            // wander.move = false;
            //wander.alive = false;
            // wander.GetComponent<Rigidbody>().freezeRotation = false;
            //this.GetComponent<EnemyStatePattern>().enabled = false;

            //this.GetComponent<EnemyStatePattern>().enabled = false;
            //GetComponent<Rigidbody>().isKinematic = false;
        }*/

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
        if (col.gameObject.tag == "Bullet" && wander.move == false)
        {
            //GetComponent<Rigidbody>().isKinematic = false;
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.BLUE)
            {

                Destroy(col.gameObject);
            }
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.YELLOW)
            {
                Debug.Log("YELLOW BULLET ENTERED");
                Destroy(col.gameObject);
            }
            /*if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.RED)
            {
                Debug.Log("RED HAS COLLIDED");
                col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                Destroy(col.gameObject);
                //wander.move = false;
                //wander.GetComponent<Rigidbody>().freezeRotation = false;
                //this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);

            }*/
            wander.move = false;
            wander.alive = false;
            wander.GetComponent<Rigidbody>().freezeRotation = false;
            this.GetComponent<EnemyStatePattern>().enabled = false;

        }
    }
}
