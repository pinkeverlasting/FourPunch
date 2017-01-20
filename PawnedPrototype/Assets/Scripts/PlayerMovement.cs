using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //REQUIERMENTS: RIGIDBODY 3D

    public float moveSpeed; //how fast you move
    private Rigidbody playerRigidbody; //rigidbody of player

    private Vector3 moveInput; //to store the change of movement based on input
    private Vector3 moveVelocity; //used to calculate the velocity based on the input

    //private Camera mainCamera; //to store the main camera object
    private GameObject followingCamera; //to store the main camera object





    void Awake(){

        Debug.Log("App Running");
    }
    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody>(); //assign this rigidbody to player rigidbody
        //mainCamera = FindObjectOfType<Camera>(); //Find camera object and set main camera as it
       followingCamera = GameObject.Find("AngledCamera"); //Find camera object and set main camera as it


    }
	
	// Update is called once per frame
	void Update () { //for normal parameter updates
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); //grab axis input and assign it to vector 3 to be used as input
        moveVelocity = moveInput * moveSpeed; //set the velocity to be the input direction times by the speed

       
		
	}

    void FixedUpdate(){ //more physics updates
        playerRigidbody.velocity = moveVelocity; //set the rigidbody velocity to be the calculated velocity
        //mainCamera.GetComponent<Rigidbody>().velocity = moveVelocity;
        //followingCamera.transform.position = transform.position;
         followingCamera.transform.position = Vector3.Lerp(followingCamera.transform.position, transform.position, Time.deltaTime*moveSpeed); //set camera position to be the lerp of its position and the position of the player times by delta time and the move speed of the player
    }
}
