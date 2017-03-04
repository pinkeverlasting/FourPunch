using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPropHandler : MonoBehaviour {

    public GameObject NozzleTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            NozzleTrigger.SendMessage("ActivateEquipment");
            Destroy(this.gameObject);
        }
    }
}
