using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    [SerializeField] private float rotationSpeed;
    //private float yRotation;
    private Transform coinTrans;
	// Use this for initialization
	void Start () {
        coinTrans = this.GetComponent<Transform>();
        //yRotation = 0;
	}

    // Update is called once per frame
    void Update()
    {

        coinTrans.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
