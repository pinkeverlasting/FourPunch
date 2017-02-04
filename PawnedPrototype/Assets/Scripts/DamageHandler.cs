using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    int enemyHealth;

	// Use this for initialization
	void Start () {
        enemyHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0)
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<BulletDeletion>() != null)
        {
            //Debug.Log("This is a bullet");
            if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.RED)
            {
                //Debug.Log("This is a RED");
                Destroy(col.gameObject);
                enemyHealth -= 10;
            }
            else if (col.gameObject.GetComponent<BulletDeletion>().catType == BulletDeletion.AmmoType.BLUE)
            {
                // Debug.Log("This is a BLUE");
                Destroy(col.gameObject);
                enemyHealth -= 25;
            }
        }
    }
}
