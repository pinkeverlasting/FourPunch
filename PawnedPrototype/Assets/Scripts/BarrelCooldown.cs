using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCooldown : MonoBehaviour {

	Renderer renderer;
	Material mat;
	float emission;
	Color baseColor;
	Color finalColor;

	public enum BarrelState //enumirator for storing the different states of Ammo
	{
		COMPLETE,
		EJECT,
		NONE
	};

	public BarrelState stateOfBarrel; //public variable for storing the state of the ammo

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		mat = renderer.material;
		stateOfBarrel = BarrelState.NONE;
	}
	
	// Update is called once per frame
	void Update () {

		emission = Mathf.PingPong (Time.time, 1.2f);

		if (stateOfBarrel == BarrelState.NONE) {
			baseColor = Color.clear; //Replace this with whatever you want for your base color at emission level '1'

			finalColor = baseColor;
			mat.SetColor("_EmissionColor", finalColor);
			mat.SetColor("_Color", Color.clear * -1f); //-0.1 turns intensity/glow off 

		} else if (stateOfBarrel == BarrelState.COMPLETE){
			baseColor = Color.green; //Replace this with whatever you want for your base color at emission level '1'

			finalColor = baseColor;
			mat.SetColor ("_EmissionColor", finalColor * 0.9f);
			mat.SetColor("_Color", Color.clear);

		} else if (stateOfBarrel == BarrelState.EJECT) {
			baseColor = Color.red; //Replace this with whatever you want for your base color at emission level '1'

			finalColor = baseColor * Mathf.LinearToGammaSpace (emission);
			mat.SetColor ("_EmissionColor", finalColor * 0.9f);
			mat.SetColor("_Color", Color.clear);
		} 
	}
}
