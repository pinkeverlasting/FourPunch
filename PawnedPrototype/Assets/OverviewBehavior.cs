using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverviewBehavior : MonoBehaviour {

   // public GameObject cinematicCamera;
    public GameObject playerCamera;

    public GameObject player;

    int checkpoint = 1;
    public GameObject checkpointObj1, checkpointObj2, checkpointObj3, checkpointObj4;

    Vector3 targetPosition;
    float speed;
    // Use this for initialization
    void Start () {
        speed = 15;
		player = GameObject.Find ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
       /* if (checkpoint == 0)
        {
            Invoke("InitiateCheckpoint", 1);
        }*/
        if (checkpoint == 4 && transform.position == targetPosition) //if the camera reaches final checkpoint
        {
            playerCamera.SetActive(true); //turn player camera on
            player.GetComponent<PlayerMovement>().canMove = true; //player can move
            this.gameObject.SetActive(false); //turn off this camera
        }

        float step = speed * Time.deltaTime; //step speed is smoothed

        if(transform.position == targetPosition) //if the position of the camera matches target position.
        {
            checkpoint += 1; //increase the checkpoint number
        }
       

        switch (checkpoint) //tracks which checkpoint the camera is going for
        {
            case 1:
                targetPosition = checkpointObj1.transform.position; //if first check point, grab position of the checkpoint object and use that as target.
                break;
            case 2:
                targetPosition = checkpointObj2.transform.position; //if it's checkpoint 2
                break;
            case 3:
                targetPosition = checkpointObj3.transform.position; //if it's checkpoint 2
                break;
            case 4:
                targetPosition = checkpointObj4.transform.position; //if it's checkpoint 2
                break;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step); //tell the camera to move torwards the ckeckpoints position.
	}

    void InitiateCheckpoint() //not used
    {
        checkpoint = 1;
    }
}
