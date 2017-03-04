using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHit2 : MonoBehaviour
{
    private EnemyStatePattern wander;

    private float force;
    private GameObject mutantObject;
    // Use this for initialization
    void Start()
    {
        mutantObject = this.gameObject;
        //wander = gameObject.GetComponent<EnemyStatePattern>();
        wander = mutantObject.GetComponent<EnemyStatePattern>();
        force = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (wander.move == false)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }*/
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
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.PURPLE)
            {
               // Debug.Log("This is a Purple");
                //wander.alive = false;
                mutantObject.GetComponent<Rigidbody>().AddExplosionForce(500, col.transform.position, 100, 200);
                Vector3 explosionPos = col.transform.position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, 30);
                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null && rb != this.GetComponent<Rigidbody>())
                        rb.AddExplosionForce(500, explosionPos, 40, 6f);

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
            if (col.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.WHITE && col.gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero)
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
