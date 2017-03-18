using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLight : MonoBehaviour {
	Renderer renderer;
	Material mat;
	float emission;
	Color baseColor;
	Color finalColor;
	public bool flashing;

	public enum AmmoState //enumirator for storing the different states of Ammo
	{
		FLASH,
		LOW,
		NONE
	};

	public AmmoState stateOfAmmo; //public variable for storing the state of the ammo

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		mat = renderer.material;
		stateOfAmmo = AmmoState.NONE;
		flashing = false;
	}

	// Update is called once per frame
	void Update () {

		emission = Mathf.PingPong (Time.time, 1.2f);

		if (stateOfAmmo == AmmoState.NONE) {
			baseColor = Color.white; //Replace this with whatever you want for your base color at emission level '1'

			finalColor = baseColor;
			mat.SetColor ("_EmissionColor", finalColor);
			mat.SetColor("_Color", Color.white * -0.1f); //-0.1 turns intensity/glow off 

		} else if (stateOfAmmo == AmmoState.LOW) {
			baseColor = Color.yellow; //Replace this with whatever you want for your base color at emission level '1'

			finalColor = baseColor;
			mat.SetColor ("_EmissionColor", finalColor * 2f);
			mat.SetColor("_Color", Color.yellow);

		} else if (stateOfAmmo == AmmoState.FLASH) {
			baseColor = Color.red; //Replace this with whatever you want for your base color at emission level '1'

			finalColor = baseColor * Mathf.LinearToGammaSpace (emission);
			mat.SetColor ("_EmissionColor", finalColor * 3f);
			mat.SetColor("_Color", Color.red);
		} 
	}

}
