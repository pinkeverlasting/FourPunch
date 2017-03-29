using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPropHandler : MonoBehaviour {

    public GameObject NozzleTrigger;
	[SerializeField] private float rotationSpeed;
	//private float yRotation;
	private Transform gunTrans;
	// Use this for initialization
	void Start () {
		gunTrans = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		gunTrans.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
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
