using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeletion : MonoBehaviour {

	[SerializeField] int deathCountdown;

    public enum AmmoType //enumirator for storing ammo types
    {
        RED,
        BLUE,
        YELLOW,
        WHITE,
        PURPLE,
        ORANGE,
        GREEN
    };

    public AmmoType catType; //stores cat ammo types

    // Use this for initialization
    void Start () {
        if(catType != AmmoType.ORANGE)
        {
            Invoke("deleteBullet", deathCountdown);
        }
		
		//Debug.Log ("Bullet created");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void deleteBullet(){
		Debug.Log ("Bullet destroyed");
		Destroy (this.gameObject); 
	}

    private void OnCollisionEnter(Collision col)
    {
        /*if (col.gameObject.tag == "Bullet")
        {
            Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), this.GetComponent<Collider>());
        }*/

        if (catType == AmmoType.BLUE && col.gameObject.tag != "Mutant" && col.gameObject.tag != "Player")
        {
            //Debug.Log(col.gameObject.tag);
            Destroy(this.gameObject);
        } 
        else if(catType == AmmoType.YELLOW && col.gameObject.tag != "Mutant" && col.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);

        }
        else if (catType == AmmoType.PURPLE && col.gameObject.tag != "Mutant" && col.gameObject.tag != "Player")
        {
            //Destroy(this.gameObject);

        }


    }
}
