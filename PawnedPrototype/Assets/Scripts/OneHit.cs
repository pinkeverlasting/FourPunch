using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHit : MonoBehaviour {
	private EnemyStatePattern wander;

    private float force;
    private GameObject mutantObject;
	public float timeBetweenEffects = 0.2f;     // seconds between effects

    private GameObject coin;
    private bool dropOnce;

	public GameObject hitEffect; 
	public float timer;
	public bool timerStart; 

    // Use this for initialization
    void Start () {
        mutantObject = transform.parent.gameObject;
        //wander = gameObject.GetComponent<EnemyStatePattern>();
        wander = mutantObject.GetComponent<EnemyStatePattern>();
        force = 1000;

		timerStart = false;
		hitEffect.SetActive (false);

        coin = GameObject.Find("catCoinPickUp");
        dropOnce = true;
    }
	
	// Update is called once per frame
	void Update () {
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
			timerStart = false;
			timer = 0f;
		}


        if (wander.alive == false)
        {
			//hitEffect.SetActive (false);

            if (dropOnce)
            {
				
                //LaunchCoin();
            }
        }
	}

    private void LaunchCoin()
    {
        GameObject tempCoinObject = Instantiate(coin, this.gameObject.transform.position, this.gameObject.transform.rotation); //set temporary bullet as the instantiated bullet
        Physics.IgnoreCollision(tempCoinObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>()); //USE THIS TO LET BULLETS THROUGH WALLS
        tempCoinObject.GetComponent<Rigidbody>().AddForce(tempCoinObject.transform.forward * 600); //add the fire force to bullet
        tempCoinObject.GetComponent<Rigidbody>().AddForce(tempCoinObject.transform.up * 300); //add the fire force to bullet
        dropOnce = !dropOnce;
    }

    private void OnTriggerEnter(Collider other)
    {

		if (other.gameObject.tag == "Bullet") {
			hitEffect.SetActive (true);
			timerStart = true;
		}

        if (other.gameObject.tag == "Bullet" && wander.alive == true)
		{

			//em.enabled = true;
			Debug.Log("RED HAS COLLIDEDDD");



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
                wander.alive = false;
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
