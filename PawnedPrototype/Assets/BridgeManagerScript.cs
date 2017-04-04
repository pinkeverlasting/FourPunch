using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManagerScript : MonoBehaviour {

    public bool firstCatPresent, secondCatPresent;
    public GameObject bridge1, bridge2;
	// Use this for initialization
	void Start () {



        bridge1.GetComponent<MoveBridge>().enabled = false;
        bridge2.GetComponent<MoveBridge>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(firstCatPresent && secondCatPresent)
        {
            Debug.Log("Activate Bridge");
            bridge1.GetComponent<MoveBridge>().enabled = true;
            bridge2.GetComponent<MoveBridge>().enabled = true;
        }
       

    }
}
