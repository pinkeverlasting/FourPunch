using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]

public class MoviePlayer : MonoBehaviour {

	public MovieTexture movie;
	private MeshRenderer meshRenderer;
	private AudioSource audio;

    public int levelIndex;

	// Use this for initialization

	void Start () {
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material.mainTexture = movie as MovieTexture;
		audio = GetComponent<AudioSource>();
		audio.Play();
		movie.Play ();
	
	}

	void Update() {

		if (!movie.isPlaying)
			Application.LoadLevel (levelIndex);
	}

}
