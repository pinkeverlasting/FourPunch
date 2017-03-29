using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridge : MonoBehaviour {

    public Transform targetDestination;
    private float speed;
	// Use this for initialization
	void Start () {
        speed = 1;

	}
	
	// Update is called once per frame
	void Update () {
        float tSpeed = speed * Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, targetDestination.position, tSpeed);
		
	}
}
