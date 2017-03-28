using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public bool damaged;
	public AudioClip impact; 
	public AudioSource audio;

	/*GUI for Health*/
	public Texture health100;
	public Texture health90;
	public Texture health75;
	public Texture health50;
	public Texture health25;
	public Texture health0;

	public Scene scene;

	/*regain health*/
	public float timeBetweenRegeneration = 1f;     // seconds between regen
	float timer;                                // Timer for counting up to the next attack.


	void Awake ()
	{
		// Set the initial health of the player.
		currentHealth = startingHealth;
		damaged = false;
		scene = SceneManager.GetActiveScene();
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
			//currentHealth = startingHealth;

			if (scene.name == "Level1") {
				Application.LoadLevel (1);
			} else if (scene.name == "Level2") {
				Application.LoadLevel (2);
			}
		}

	}


	public void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;

		// Reduce the current health by the damage amount.
		currentHealth -= amount;

	}

	void OnGUI() {

		if (currentHealth == 100) {
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), health100);
			//Debug.Log ("Current Health: " + currentHealth);
		} else if (currentHealth < 100 && currentHealth >= 80) {
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), health90);
			Debug.Log (currentHealth);
		} else if (currentHealth < 80 && currentHealth >= 60) {
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), health75);
			Debug.Log (currentHealth);
		} else if (currentHealth < 60 && currentHealth >= 40) {
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), health50);
			Debug.Log (currentHealth);
		} else if (currentHealth < 40 && currentHealth >= 20) {
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), health25);
			Debug.Log (currentHealth);
		} else if (currentHealth < 20 || currentHealth <= 0) {
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), health0);
			Debug.Log (currentHealth);
		}

	}




}