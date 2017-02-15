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
        WHITE
    };

    public AmmoType catType; //stores cat ammo types

    // Use this for initialization
    void Start () {
		Invoke ("deleteBullet", deathCountdown);
		Debug.Log ("Bullet created");
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
        if (catType == AmmoType.BLUE && col.gameObject.tag != "Mutant" && col.gameObject.tag != "Player")
        {
            //Debug.Log(col.gameObject.tag);
            Destroy(this.gameObject);
        }
    }
}
