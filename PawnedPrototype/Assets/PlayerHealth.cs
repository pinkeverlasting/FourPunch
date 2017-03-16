using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 200;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public bool damaged;
	public AudioClip impact; 
	public AudioSource audio;

	void Awake ()
	{
		// Set the initial health of the player.
		currentHealth = startingHealth;
		damaged = false;
	}


	void Update ()
	{
		//Debug.Log (currentHealth);
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			audio.PlayOneShot(impact);
		}
		// Reset the damaged flag.
		damaged = false;

		if (currentHealth <= 0) {
			currentHealth = startingHealth;
		}
	}


	public void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;

		// Reduce the current health by the damage amount.
		currentHealth -= amount;

	}
		
}
