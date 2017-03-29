using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleCatDetector : MonoBehaviour {

   // public GameObject catObject;
    public GameObject startingCat;
	// Use this for initialization
	void Start () {
		if(startingCat != null)
        {
            //Physics.IgnoreCollision(GetComponent<Collider>(), startingCat.GetComponent<Collider>());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ammo")
        {
            if(other.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.YELLOW && other.gameObject.GetComponent<CatStatePattern>() != null)
            {
                Debug.Log("Cat Entered Generator");
                other.gameObject.GetComponent<CatStatePattern>().enabled = false;
               // Debug.Log(other.gameObject.GetComponent<CatStatePattern>());
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            if (other.gameObject.GetComponent<AmmoTypeScript>().catType == AmmoTypeScript.AmmoType.YELLOW && other.gameObject.GetComponent<CatStatePattern>() != null)
            {
                Debug.Log("Cat Entered Generator");
                other.gameObject.GetComponent<CatStatePattern>().enabled = true;
                // Debug.Log(other.gameObject.GetComponent<CatStatePattern>());
            }

        }
    }
}
