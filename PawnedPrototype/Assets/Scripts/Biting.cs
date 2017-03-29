using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biting : MonoBehaviour {

	public float timeBetweenAttacks = 1f;     // seconds between attack
	public int attackDamage = 10;               // health taken per attack.


	GameObject player;                          // player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
	EnemyStatePattern enemy; 					 // Enemy's Core Files
	bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
	float timer;                                // Timer for counting up to the next attack.
	public EnemyStatePattern mutantObject;

	public HealthShake cameraShake;

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.Find("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		cameraShake = GameObject.Find ("Main Camera").GetComponent<HealthShake> ();
		mutantObject = transform.parent.gameObject.GetComponent<EnemyStatePattern>();
	}


	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(other.gameObject == player && mutantObject.alive == true)
		{
			// ... the player is in range.

			if (mutantObject.enabled == true) {
				playerInRange = true;
				playerHealth.regen = false;
				Debug.Log ("health");
			}
		}
	}


	void OnTriggerExit (Collider other)
	{
		// If the exiting collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is no longer in range.
			playerHealth.regen = true;
			playerInRange = false;
		}
	}


	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;

		// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if(timer >= timeBetweenAttacks && playerInRange)
		{
			// ... attack.
			Attack ();
		}

	}


	void Attack ()
	{
		// Reset the timer.
		timer = 0f;

		// If the player has health to lose...
		if(playerHealth.currentHealth > 0)
		{
			// ... damage the player.
			cameraShake.shakeDuration = 1.0f;
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
