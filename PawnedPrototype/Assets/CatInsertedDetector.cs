using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInsertedDetector : MonoBehaviour {

    public bool firstConsole;
    public GameObject bridgeManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            if (other.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.YELLOW)
            {
                if (firstConsole)
                {
                    bridgeManager.GetComponent<BridgeManagerScript>().firstCatPresent = true;
                }
                else
                {
                    bridgeManager.GetComponent<BridgeManagerScript>().secondCatPresent = true;
                }
            }

        }
    }
}
