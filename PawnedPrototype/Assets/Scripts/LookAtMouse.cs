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
	private RaycastHit oldRayHit;
	private int layerMask;

    private Transform currentLookAtPoint;
    [SerializeField] private float lerpSpeed;

    private bool checkControlOnce;

    //public GameObject playerContainer;

    // Use this for initialization
    private void Awake()
    {
        // this.GetComponent<FadeInOut>().Fade();
        // this.GetComponent<FadeInOut>().SendMessage("OnGUI");
        //Debug.Log("called fade");

        checkControlOnce = true;
    }

    void Start () {
        mainCamera = FindObjectOfType<Camera>(); //Find camera object and set main camera as it
        playerObject = GameObject.Find("Player"); //find player object
        playerTransform = playerObject.GetComponent<Transform>();

        fakePlane = GameObject.Find("FakeFloor");

        currentLookAtPoint = GameObject.Find("CurrentLookAt").GetComponent<Transform>();
        currentLookAtPoint.position = new Vector3(currentLookAtPoint.transform.position.x, playerTransform.position.y, currentLookAtPoint.transform.position.z);

        
    }
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<FadeInOut>().GetAlpha() <= 0.4f && checkControlOnce)
        {
            playerObject.GetComponent<PlayerMovement>().canMove = true;
            checkControlOnce = false;
            //Debug.Log("can Move");
        }

		layerMask = 1 << 8;
		layerMask = ~layerMask;
        RaycastHit groundRayHit; //for storing the ray data of where it hit the ground
        //float groundRayHit;
        Vector3 groundRay = playerTransform.TransformDirection(Vector3.down); //the ray itself that goes from the players position down

       /* if (Physics.Raycast(playerTransform.position, groundRay, out groundRayHit)) //if the raycast from the players position, using the ground ray, hits anything, output the results to ground ray hit
        {

           // float distance = groundRayHit.distance; //set the distance from player to ground to be the rayHit distance
           // Debug.Log(distance); //show the distance
            //playerTransform.rotation = Quaternion.FromToRotation(Vector3.up, groundRayHit.normal);
            //playerTransform.up = groundRayHit.normal;
            //playerContainer.transform.up = groundRayHit.normal;
            //playerContainer.transform.rotation = Quaternion.FromToRotation(Vector3.up, groundRayHit.normal);

        }*/
		//Debug.DrawRay(playerTransform.position, groundRay, Color.green, 5f);
		//oldRayHit = groundRayHit;
		Physics.Raycast(playerTransform.position, groundRay, out groundRayHit, 5f, layerMask); //the raycast from the players position, using the ground ray, hits anything, output the results to ground ray hit

		//if (Physics.Raycast (playerTransform.position, groundRay, out groundRayHit, 5f)) {
//		Debug.Log (groundRayHit.collider.gameObject);
		//}

		//if (groundRayHit.collider.tag == "Mutant") {
			//groundRayHit = oldRayHit;
		//} else {
			//oldRayHit = groundRayHit;
		//}


        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition); //create a ray from the camera to the mouse
        //Plane groundPlane = new Plane(Vector3.up, Vector3.zero); //create a test plane facing up and on world origin
       //Plane groundPlane = new Plane(Vector3.up, fakePlane.transform.position); //create a test plane facing up and on world origin
       Plane groundPlane = new Plane(groundRayHit.normal, fakePlane.transform.position); //create a test plane facing to the normal and on the players fake ground origin. GROUND PLANE IS ZEROED TO THE ORIGIN OF THE PLAYER AND IT BENDS DEPENDING ON THE NORMAL OF THE GROUND
        float rayLength; //for storing the length of the ray




        if (groundPlane.Raycast(cameraRay, out rayLength)) //if the camera ray intersects with the fictional ground plane, do if statement and save the length to ray length
        {
            Vector3 intersectPoint = cameraRay.GetPoint(rayLength); //find the point intersecting  at by grabing that point from camera ray with the ray length
			//lookAtPoint = new Vector3(intersectPoint.x, playerTransform.position.y, intersectPoint.z); //set the looking point to be the x and z of the intersecting point and the y of the player point
            lookAtPoint = new Vector3(intersectPoint.x, intersectPoint.y, intersectPoint.z); //the look at point is a new vector using the intersecting points found from the ray hit. POSITION Y DOESNT MATTER AS IT IS ALWAYS ZEROED ON THE PLAYERS POSITION
            Debug.DrawLine(cameraRay.origin, lookAtPoint, Color.blue); //test the point with a draw line from origin (camera) of cameraRay to look point with the color blue

            //transform.LookAt(lookAtPoint); //call look at and look at the look at point
            //playerObject.GetComponent<Transform>().LookAt(lookAtPoint);
            //Debug.Log(lookAtPoint);

            // followingCamera.transform.position = Vector3.Lerp(followingCamera.transform.position, transform.position, Time.deltaTime * moveSpeed);
            currentLookAtPoint.position = Vector3.Lerp(currentLookAtPoint.transform.position, lookAtPoint, Time.deltaTime * lerpSpeed); //the current look at point is a lerp if its current look at and the new look at point with a smooth of lerp speed over time

            // playerTransform.LookAt(lookAtPoint);
           
        }
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, groundRayHit.normal);
        // rot = rot * Quaternion.FromToRotation(Vector3.forward, lookAtPoint);

        /*lookAtPoint.y = 0;
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, groundRayHit.normal);
        rot = rot * Quaternion.FromToRotation(Vector3.forward, lookAtPoint);
        //Quaternion rot = Quaternion.FromToRotation(playerTransform.forward, lookAtPoint);
        Debug.Log(rot);
        //Quaternion newRot = Quaternion.Slerp(playerTransform.rotation, rot, Time.deltaTime * lerpSpeed);

        playerTransform.rotation = rot;*/

       
       


       // playerTransform.up = groundRayHit.normal;
        // playerTransform.forward = currentLookAtPoint.position;
       //playerTransform.LookAt(currentLookAtPoint.position); //set the player to look at the current look at position. ADD NORMAL HERE

       playerTransform.LookAt(currentLookAtPoint.position, groundRayHit.normal); //set the player to look at the current look at position. ADD NORMAL HERE. THE FAKE GROUND PLANE NORMAL ALWAYS FOLLOW THE EYE LEVEL AND SO THE LOOK AT ALWAYS STAYS ALIGNED TO THE NORMAL THE MODEL SHOULD FOLLOW

    }
    void FixedUpdate()
    { //more physics updates
        //playerRigidbody.velocity = moveVelocity; //set the rigidbody velocity to be the calculated velocity

    }
}
