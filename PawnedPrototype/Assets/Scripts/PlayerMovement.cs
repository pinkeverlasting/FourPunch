using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    //REQUIERMENTS: RIGIDBODY 3D

    public float moveSpeed; //how fast you move
    private float normalWalkingSpeed;
    private float vacuumWalkingSpeed;

    private Rigidbody playerRigidbody; //rigidbody of player

    private Vector3 moveInput; //to store the change of movement based on input
    private Vector3 moveVelocity; //used to calculate the velocity based on the input

    public float gravity; //gravity acting on player
    private float originalGravity;

    //private Camera mainCamera; //to store the main camera object
    private GameObject followingCamera; //to store the main camera object

    public bool canMove;

    private int coinAmount;
    public Text coinText;

    public GameObject passObject;

    public bool hasFirstPass;



    void Awake(){

        Debug.Log("App Running");
    }
    // Use this for initialization
    void Start () {
       playerRigidbody = GetComponent<Rigidbody>(); //assign this rigidbody to player rigidbody
        //mainCamera = FindObjectOfType<Camera>(); //Find camera object and set main camera as it
       followingCamera = GameObject.Find("AngledCamera"); //Find camera object and set main camera as it
       originalGravity = gravity;
        normalWalkingSpeed = moveSpeed;
        vacuumWalkingSpeed = normalWalkingSpeed / 2;

        coinAmount = 0;
        if(coinText != null)
        {
            coinText.text = coinAmount.ToString();
        }

        if (hasFirstPass)
        {
            passObject.SetActive(true);
        }
        
       // canMove = false;


    }
	
	// Update is called once per frame
	void Update () { //for normal parameter updates
                     //moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); //grab axis input and assign it to vector 3 to be used as input
       // Debug.Log(GameObject.Find("Main Camera"));
       if (canMove)
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized; //grab axis input and assign it to vector 3 to be used as input
        }
        else
        {
            moveInput = Vector3.zero;
        }
       
       
       // moveVelocity = moveInput * moveSpeed; //set the velocity to be the input direction times by the speed
        moveInput = moveInput * moveSpeed; //multiply the input vector by the speed of the player
       // moveInput = moveSpeed * transform.TransformDirection(moveInput);
        //moveInput.y = playerRigidbody.velocity.y;

        //Debug.Log(Input.GetAxisRaw("Horizontal")+";"+Input.GetAxisRaw("Vertical"));
        /* if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
         {
             //Debug.Log("BOOST");
             //moveInput = moveInput / 2;
             float newMoveSpeedX =  (moveInput.x / (Mathf.Sqrt(2)));
             float newMoveSpeedZ = (moveInput.z / (Mathf.Sqrt(2)));
             //moveVelocity = new Vector3(moveInput.x/2, gravity, moveInput.z/2);//set the velocity to be the input direction times by the speed
             moveVelocity = new Vector3(newMoveSpeedX, gravity, newMoveSpeedZ);//set the velocity to be the input direction times by the speed
         }
         else
         {
             moveVelocity = new Vector3(moveInput.x, gravity, moveInput.z);//set the velocity to be the input direction times by the speed
         }*/
        //moveVelocity = new Vector3(moveInput.x, gravity, moveInput.z);//set the velocity to be the input direction times by the speed
        moveVelocity = new Vector3(moveInput.x, gravity, moveInput.z);//set the velocity to be the input direction with gravity added

        //moveVelocity = transform.TransformDirection(moveVelocity);
        //moveVelocity = moveVelocity.normalized;

        /* // get the direction it must walk in:
         var speed = Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
         // convert from local to world space and multiply by horizontal speed:
         speed = horSpeed * transform.TransformDirection(speed);
         // keep rigidbody vertical velocity to preserve gravity action:
         speed.y = rigidbody.velocity.y;
         // set new rigidbody velocity:
         rigidbody.velocity = speed;*/



    }

    void FixedUpdate(){ //more physics updates
        if (canMove)
        {
            playerRigidbody.velocity = moveVelocity; //set the rigidbody velocity to be the calculated velocity
        }
       
        //Debug.Log(playerRigidbody.velocity.y);
        //Debug.Log(gravity);
        //playerRigidbody.velocity = moveInput; //set the rigidbody velocity to be the calculated velocity

        // transform.position += moveVelocity;
        //mainCamera.GetComponent<Rigidbody>().velocity = moveVelocity;
        //followingCamera.transform.position = transform.position;
        followingCamera.transform.position = Vector3.Lerp(followingCamera.transform.position, transform.position, Time.deltaTime*moveSpeed); //set camera position to be the lerp of its position and the position of the player times by delta time and the move speed of the player
    }

    public void ResetGravity() //resets gravity back to original settings
    {
        gravity = originalGravity;
    }

    public void SetToWalkingSpeed()
    {
        moveSpeed = normalWalkingSpeed;
    }
   public void SetToSuckingSpeed()
    {
        moveSpeed = vacuumWalkingSpeed;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Mutant" && col.gameObject.GetComponent<EnemyWander>() != null)
        {
            // Debug.Log("Mutant!");
            //col.gameObject.GetComponent<EnemyWander>().SendMessage("getwayPoint");
        }

        if (col.gameObject.tag == "PickUp")
        {
            if(col.gameObject.name == "passPickUp") //if you pick up a pass
            {

                passObject.SetActive(true);
            }
            else //if it's a coin
            {
                coinAmount += 1;
                coinText.text = coinAmount.ToString(); //track coin ammount
            }
            Destroy(col.gameObject);

        }

    }



}
