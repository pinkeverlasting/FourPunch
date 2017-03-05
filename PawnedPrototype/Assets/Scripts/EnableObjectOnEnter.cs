using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectOnEnter : MonoBehaviour {

    public GameObject objectToEnable;
	// Use this for initialization
	void Start () {
        objectToEnable.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectToEnable.SetActive(true);
        }
    }
}
