using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler2 : MonoBehaviour
{
    //public CharacterController controller;
    //private MutantStalker look;
    int enemyHealth;
    private GameObject mutantObject;
    private EnemyStatePattern wander;

    //IMMUNITIES
    //public bool isImmune;
    public int immuneTypeInt; //1 is blue, 2 is red, 3 is yellow


    // Use this for initialization
    void Start()
    {
        enemyHealth = 100;
        if(immuneTypeInt == 1) //blue
        {
            enemyHealth = 600;
        }else if (immuneTypeInt == 2) //red
        {
            enemyHealth = 480;
        }

        mutantObject = this.gameObject;
        wander = gameObject.GetComponent<EnemyStatePattern>();

        // Debug.Log(wander);
        //look = gameObject.GetComponent<MutantStalker>();
        //controller = GetComponent<CharacterController> ();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(enemyHealth);
        if (enemyHealth <= 0)
        {
            //look.alive = false; 
            // wander.GetComponent<Rigidbody>().freezeRotation = false;

            mutantObject.GetComponent<Rigidbody>().freezeRotation = false;
            // this.GetComponent<Rigidbody>().isKinematic = false;
            //this.GetComponent<EnemyStatePattern>().enabled = false;

            mutantObject.GetComponent<EnemyStatePattern>().enabled = false;
            //wander.alive = false;
            //this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("HIT");
        }
        if (col.gameObject.GetComponent<BulletDeletion>() != null && enemyHealth > 0)
        {
            //Debug.Log("This is a bullet");
            //MORE AMMO TYPES AND CAT DAMAGE
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.RED && immuneTypeInt != 2)
            {
                Debug.Log("This is a RED");
                col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                col.gameObject.GetComponent<Transform>().rotation = Quaternion.identity;
                Destroy(col.gameObject);
                enemyHealth -= 10;
            }
            else if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.BLUE && immuneTypeInt != 1)
            {
                Debug.Log("This is a BLUE");
                Destroy(col.gameObject);
                enemyHealth -= 34;
            }
            else if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.YELLOW && immuneTypeInt != 3)
            {
                Debug.Log("This is a Yellow");
                Destroy(col.gameObject);
                enemyHealth -= 60; //THIS SHOULDNT KILL THE MUTANT
            }
            else if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.PURPLE)
            {
                Debug.Log("This is a Purple");
                wander.alive = false;
                
               
                mutantObject.GetComponent<Rigidbody>().AddExplosionForce(500, col.transform.position, 100, 200);
                enemyHealth -= 110; //THIS SHOULDNT KILL THE MUTANT
                Vector3 explosionPos = col.transform.position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, 30);
                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null && rb != this.GetComponent<Rigidbody>())
                    {
                        if (rb.gameObject.tag == "Mutant")
                        {
                            rb.gameObject.GetComponent<EnemyStatePattern>().alive = false;
                            rb.gameObject.SendMessage("StunTimer");
                        }
                        rb.AddExplosionForce(500, explosionPos, 40, 6f);
                    }
                        

                }

                // enemyHealth -= 10; //THIS SHOULDNT KILL THE MUTANT
                Destroy(col.gameObject);
                //enemyHealth -= 10; //THIS SHOULDNT KILL THE MUTANT

                //rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
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
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.RED)
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
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.PURPLE)
            {

                // mutantObject.GetComponent<Rigidbody>().AddExplosionForce(1000, col.transform.position, 100, 1000);
                mutantObject.GetComponent<Rigidbody>().AddExplosionForce(500, col.transform.position, 100, 200);
                Vector3 explosionPos = col.transform.position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, 30);
                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null && rb != this.GetComponent<Rigidbody>())
                    {
                        if (rb.gameObject.tag == "Mutant")
                        {
                            rb.gameObject.GetComponent<EnemyStatePattern>().alive = false;
                            rb.gameObject.SendMessage("StunTimer");
                        }
                        rb.AddExplosionForce(500, explosionPos, 40, 6f);
                    }

                }

                // enemyHealth -= 10; //THIS SHOULDNT KILL THE MUTANT
                Destroy(col.gameObject);

            }

        }
        if (col.gameObject.tag == "Ammo" && wander.alive == true && col.gameObject.GetComponent<AmmoTypeScript>() != null)
        {
            if (col.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.WHITE && col.gameObject.transform.position.y > transform.position.y)
            {
                if (enemyHealth <= 50)
                {
                    enemyHealth -= 60;
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        


    }
}
