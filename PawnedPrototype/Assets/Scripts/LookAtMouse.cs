using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {
    //REQUIERMENTS: CAMERA


    private Camera mainCamera; //to store the main camera object

    private Vector3 lookAtPoint; //the point that the player will look at

    private GameObject playerObject; //to store the player game object
    private Transform playerTransform; //to store the transform of the player

    private GameObject fakePlane;

    // Use this for initialization
    void Start () {
        mainCamera = FindObjectOfType<Camera>(); //Find camera object and set main camera as it
        playerObject = GameObject.Find("Player"); //find player object
        playerTransform = playerObject.GetComponent<Transform>();

        fakePlane = GameObject.Find("FakeFloor");
    }
	
	// Update is called once per frame
	void Update () {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition); //create a ray from the camera to the mouse
        //Plane groundPlane = new Plane(Vector3.up, Vector3.zero); //create a test plane facing up and on world origin
        Plane groundPlane = new Plane(Vector3.up, fakePlane.transform.position); //create a test plane facing up and on world origin
        float rayLength; //for storing the length of the ray




        if (groundPlane.Raycast(cameraRay, out rayLength)) //if the camera ray intersects with the fictional ground plane, do if statement and save the length to ray length
        {
            Vector3 intersectPoint = cameraRay.GetPoint(rayLength); //find the point intersecting  at by grabing that point from camera ray with the ray length
            lookAtPoint = new Vector3(intersectPoint.x, playerTransform.position.y, intersectPoint.z); //set the looking point to be the x and z of the intersecting point and the y of the player point

            Debug.DrawLine(cameraRay.origin, lookAtPoint, Color.blue); //test the point with a draw line from origin (camera) of cameraRay to look point with the color blue

            //transform.LookAt(lookAtPoint); //call look at and look at the look at point
            //playerObject.GetComponent<Transform>().LookAt(lookAtPoint);
            playerTransform.LookAt(lookAtPoint);
        }

    }
    void FixedUpdate()
    { //more physics updates
        //playerRigidbody.velocity = moveVelocity; //set the rigidbody velocity to be the calculated velocity

    }
}
