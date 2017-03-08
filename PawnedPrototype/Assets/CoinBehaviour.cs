using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    [SerializeField] private float rotationSpeed;
    //private float yRotation;
    private Transform coinTrans;
    public bool isPass;
	// Use this for initialization
	void Start () {
        coinTrans = this.GetComponent<Transform>();
        //yRotation = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (!isPass)
        {
           coinTrans.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else
        {
            coinTrans.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
        
    }
}
