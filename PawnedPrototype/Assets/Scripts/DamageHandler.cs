using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {
	//public CharacterController controller;
	//private MutantStalker look;
    int enemyHealth;
   private GameObject mutantObject;
    private EnemyStatePattern wander;
   

    // Use this for initialization
    void Start () {
        enemyHealth = 100;

        mutantObject = transform.parent.gameObject;
       wander = gameObject.GetComponent<EnemyStatePattern>();
       // Debug.Log(wander);
        //look = gameObject.GetComponent<MutantStalker>();
        //controller = GetComponent<CharacterController> ();

    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(enemyHealth);
		if (enemyHealth <= 0)
        {
            //look.alive = false; 
            // wander.GetComponent<Rigidbody>().freezeRotation = false;

            mutantObject.GetComponent<Rigidbody>().freezeRotation = false;
            // this.GetComponent<Rigidbody>().isKinematic = false;
            //this.GetComponent<EnemyStatePattern>().enabled = false;

        mutantObject.GetComponent<EnemyStatePattern>().enabled = false;
            //this.GetComponent<Rigidbody>().isKinematic = false;
        }
	}

	private void OnCollisionEnter (Collision col)
	{ 

		if (col.gameObject.tag == "Bullet") {
			Debug.Log ("HIT");
		}
        if (col.gameObject.GetComponent<BulletDeletion>() != null && enemyHealth > 0)
        {
            //Debug.Log("This is a bullet");
            //MORE AMMO TYPES AND CAT DAMAGE
           if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.RED)
            {
                Debug.Log("This is a RED");
                col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                col.gameObject.GetComponent<Transform>().rotation = Quaternion.identity;
                Destroy(col.gameObject);
               enemyHealth -= 10;
            }
            else if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.BLUE)
            {
                Debug.Log("This is a BLUE");
                Destroy(col.gameObject);
                enemyHealth -= 34;
            }
            else if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.YELLOW)
            {
                Debug.Log("This is a Yellow");
                Destroy(col.gameObject);
                enemyHealth -= 60; //THIS SHOULDNT KILL THE MUTANT
            }
        }
        if (col.gameObject.tag == "Bullet" && enemyHealth <= 0)
        {
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.BLUE)
            {
                Destroy(col.gameObject);
            }
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.YELLOW)
            {
                Destroy(col.gameObject);
            }
            if(col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.RED)
            {
                Debug.Log("This is a RED2");
               // Destroy(col.gameObject.GetComponent<Rigidbody>());
               //this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
              //  this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
               //this.gameObject.GetComponent<Transform>().rotation = Quaternion.identity;
                //col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                //col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                //col.gameObject.GetComponent<Transform>().rotation = Quaternion.identity;
                //Destroy(col.gameObject);
                //enemyHealth -= 10;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
           if (other.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.RED)
            {
                //Debug.Log("RED HAS COLLIDED");
                //wander.move = false;
                Destroy(other.gameObject);
                enemyHealth -= 5;
                // GetComponent<Rigidbody>().isKinematic = false;
                if (enemyHealth <= 0 && mutantObject.GetComponent<EnemyStatePattern>().enabled == true)
                {
                    //look.alive = false; 
                   // wander.GetComponent<Rigidbody>().freezeRotation = false;

                    mutantObject.GetComponent<Rigidbody>().freezeRotation = false;

                    // this.GetComponent<Rigidbody>().isKinematic = false;
                    mutantObject.GetComponent<EnemyStatePattern>().enabled = false;
                    //this.GetComponent<Rigidbody>().isKinematic = false;
                    mutantObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);
                    //look.alive = false;
                }
                //this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);

            }
           if (other.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.ORANGE)
            {
               // Debug.Log("OrangeInbound");
                enemyHealth -= 60;

                if (enemyHealth <= 0 && mutantObject.GetComponent<EnemyStatePattern>().enabled == true)
                {
                    //look.alive = false; 
                    // wander.GetComponent<Rigidbody>().freezeRotation = false;

                    mutantObject.GetComponent<Rigidbody>().freezeRotation = false;

                    // this.GetComponent<Rigidbody>().isKinematic = false;
                    mutantObject.GetComponent<EnemyStatePattern>().enabled = false;
                    mutantObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);
                    //this.GetComponent<Rigidbody>().isKinematic = false;

                    //look.alive = false;
                }
                else if (enemyHealth <= 0 && mutantObject.GetComponent<EnemyStatePattern>().enabled == false)
                {
                    mutantObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);
                }
            }
            //wander.move = false;
           // wander.alive = false;
            //this.GetComponent<EnemyStatePattern>().enabled = false;
           // GetComponent<Rigidbody>().isKinematic = false;
        }


    }
}
