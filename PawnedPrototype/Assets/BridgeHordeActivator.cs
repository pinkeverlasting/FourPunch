using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeHordeActivator : MonoBehaviour {
    public GameObject bridgeMutants;

	// Use this for initialization
	void Start () {
        bridgeMutants.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bridgeMutants.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
