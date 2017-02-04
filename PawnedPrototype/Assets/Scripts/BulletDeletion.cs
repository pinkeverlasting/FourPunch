using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeletion : MonoBehaviour {

	[SerializeField] int deathCountdown;

    public enum AmmoType //enumirator for storing ammo types
    {
        RED,
        BLUE
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
}
