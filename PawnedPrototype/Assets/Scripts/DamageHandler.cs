using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {
	//public CharacterController controller;
	private MutantStalker look;
    int enemyHealth;

	// Use this for initialization
	void Start () {
        enemyHealth = 100;
		look = gameObject.GetComponent<MutantStalker>();
		//controller = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0)
        {	
			look.alive = false; 
            this.GetComponent<Rigidbody>().isKinematic = false;
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
                Destroy(col.gameObject);
                enemyHealth -= 10;
            }
            else if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.BLUE)
            {
                Debug.Log("This is a BLUE");
                Destroy(col.gameObject);
                enemyHealth -= 34;
            }
        }
    }
}
