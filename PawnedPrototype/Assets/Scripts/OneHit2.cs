using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHit2 : MonoBehaviour
{
    private EnemyStatePattern wander;

    private float force;
    private GameObject mutantObject;

	public float timeBetweenEffects = 0.2f;     // seconds between effects
	public GameObject hitEffect; 
	public GameObject iceEffect; 
	public float timer;
	public bool timerStart; 

    private GameObject coin;
    private bool dropOnce; //to make sure coins are only dropped once

    private bool hasChaseOnWake;
	public GameObject animation; 
	bool tierOne; 
	public AudioClip success;
	public AudioSource audio;

    // Use this for initialization
    void Start()
    {
		tierOne = true;
        mutantObject = this.gameObject;
        //wander = gameObject.GetComponent<EnemyStatePattern>();
        wander = mutantObject.GetComponent<EnemyStatePattern>();
		if (tierOne) {
			animation.GetComponent<Animator> ().enabled = true;
		}
        force = 1000;
        coin = GameObject.Find("catCoinPickUp");
        dropOnce = true;

		timerStart = false;
		hitEffect.SetActive (false);
		iceEffect.SetActive (false);

        if(this.gameObject.GetComponent<ChaseOnWake>() != null)
        {
            hasChaseOnWake = true;
        }
        else
        {
            hasChaseOnWake = false;
        }


	
    }

    // Update is called once per frame
    void Update()
    {
        /*if (wander.move == false)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }*/

		if (timerStart) {
			timer += Time.deltaTime;
		} 

		if(timer >= timeBetweenEffects)
		{
			hitEffect.SetActive (false);
			iceEffect.SetActive (false);
			timerStart = false;
			timer = 0f;
		}


        if (wander.alive == false)
        {
			hitEffect.SetActive (false);
			if (tierOne) {
				animation.GetComponent<Animator> ().enabled = false;
			}
            if (hasChaseOnWake)
            {
                this.GetComponent<ChaseOnWake>().enabled = false;
            }

            if (GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
            {
                GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                GetComponent<AgentWalkTo>().enabled = false;
                if(GetComponent<Rigidbody>().isKinematic == true)
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 500);
                }
                Invoke("DeleteMutant", 15);
            }


                if (dropOnce)
            {
                LaunchCoin();
            }
        }
    }

    private void LaunchCoin() //when dead, it launches a coin to collect
    {
        GameObject tempCoinObject = Instantiate(coin, this.gameObject.transform.position, this.gameObject.transform.rotation); //set temporary bullet as the instantiated bullet
        Physics.IgnoreCollision(tempCoinObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>()); //USE THIS TO LET BULLETS THROUGH WALLS
       // tempCoinObject.GetComponent<Rigidbody>().AddForce(tempCoinObject.transform.forward * 600); //add the fire force to bullet
       // tempCoinObject.GetComponent<Rigidbody>().AddForce(tempCoinObject.transform.up * 300); //add the fire force to bullet
        dropOnce = !dropOnce;
    }

    private void DeleteMutant()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
   


    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.gameObject.tag == "Bullet" && wander.move == true)
		{
			//GetComponent<Rigidbody>().isKinematic = true;
		}*/
    }
    private void OnCollisionEnter(Collision col)
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
			hitEffect.SetActive (true);
			timerStart = true;
			audio.PlayOneShot(success);

            //GetComponent<Rigidbody>().isKinematic = false;
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.PURPLE)
            {
                //Debug.Log("This is a Purple");
                wander.alive = false;
                mutantObject.GetComponent<Rigidbody>().AddExplosionForce(280, col.transform.position, 100, 1);
                //enemyHealth -= 10; //THIS SHOULDNT KILL THE MUTANT
                Destroy(col.gameObject);
                //enemyHealth -= 10; //THIS SHOULDNT KILL THE MUTANT

                //rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
            wander.move = false;


            //Vector3 dir = col.contacts[0].point - transform.position;
            //Vector3 dir = transform.position - col.gameObject.transform.position;
            //dir = -dir.normalized;
            // Debug.Log(dir);
            // this.GetComponent<Rigidbody>().AddForce(dir*force);


            Destroy(col.gameObject);

            this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 20);
            this.GetComponent<EnemyStatePattern>().enabled = false;


            //GetComponent<Rigidbody>().isKinematic = false;
        }
        if (col.gameObject.tag == "Bullet" && wander.move == false)
        {
            //GetComponent<Rigidbody>().isKinematic = false;
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.BLUE)
            {
				iceEffect.SetActive (true);

				timerStart = true;
                Destroy(col.gameObject);
            }
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.YELLOW)
            {
                Debug.Log("YELLOW BULLET ENTERED");
                Destroy(col.gameObject);

                
            }
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.PURPLE)
            {
                // Debug.Log("This is a Purple");
                //wander.alive = false;
                if (GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
                {
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    GetComponent<AgentWalkTo>().enabled = false;
                    if (GetComponent<Rigidbody>().isKinematic == true)
                    {
                        GetComponent<Rigidbody>().isKinematic = false;
                        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 500);
                    }
                    Invoke("DeleteMutant", 15);
                }

                mutantObject.GetComponent<Rigidbody>().AddExplosionForce(500, col.transform.position, 100, 200);
                Vector3 explosionPos = col.transform.position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, 30);
                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null && rb != this.GetComponent<Rigidbody>())
                        rb.AddExplosionForce(150, explosionPos, 40, 2f);

                }

                // enemyHealth -= 10; //THIS SHOULDNT KILL THE MUTANT
                Destroy(col.gameObject);
                //enemyHealth -= 10; //THIS SHOULDNT KILL THE MUTANT

                //rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
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
        if (col.gameObject.tag == "Ammo" && wander.alive == true && col.gameObject.GetComponent<AmmoTypeScript>() != null)
        {
            if (col.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.WHITE && col.gameObject.transform.position.y > transform.position.y)
            {
                mutantObject.GetComponent<Rigidbody>().freezeRotation = false;

                // this.GetComponent<Rigidbody>().isKinematic = false;
                mutantObject.GetComponent<EnemyStatePattern>().enabled = false;
                //this.GetComponent<Rigidbody>().isKinematic = false;
                mutantObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);
                wander.alive = false;
            }

        }
    }
}
