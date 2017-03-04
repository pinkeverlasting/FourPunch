﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeController : MonoBehaviour {

    public GameObject dialText;

	// Use this for initialization
	void Start () {
        dialText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            dialText.SetActive(true);
            Invoke("StopDial", 15);
        }
    }
    private void StopDial()
    {
        dialText.SetActive(false);
    }
}
