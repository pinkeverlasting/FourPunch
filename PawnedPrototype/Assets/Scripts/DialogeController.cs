using System.Collections;
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
        if(other.gameObject.tag == "Player") //if player approaches, show text
        {
            dialText.SetActive(true);
            Invoke("StopDial", 15);
        }
    }
    private void OnTriggerExit(Collider other) //turns off text if you leave
    {
        if (other.gameObject.tag == "Player")
        {
            dialText.SetActive(false);
            
        }
    }
    private void StopDial() //turns off text if you stay too long
    {
        dialText.SetActive(false);
    }
}
