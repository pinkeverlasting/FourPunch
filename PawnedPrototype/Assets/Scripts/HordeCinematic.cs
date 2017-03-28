using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeCinematic : MonoBehaviour {
    public GameObject playerCamera;

    public GameObject player;

    public GameObject checkpointObj1;

    public GameObject fakeHorde;

    public GameObject realHorde;

    Vector3 targetPosition;
    float speed;
    // Use this for initialization
    void Start () {
        speed = 15;
        player = GameObject.Find("Player");
        //fakeHorde.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position == targetPosition) //if the camera reaches final checkpoint
        {
            Invoke("ReachedTarget", 1);
           // playerCamera.SetActive(true); //turn player camera on
            //player.GetComponent<PlayerMovement>().canMove = true; //player can move
            //this.gameObject.SetActive(false); //turn off this camera
        }
        else
        {
            float step = speed * Time.deltaTime; //step speed is smoothed

            targetPosition = checkpointObj1.transform.position;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step); //tell the camera to move torwards the ckeckpoints position.
        }
        
    }

    void ReachedTarget()
    {
        foreach (Transform child in fakeHorde.transform)
        {
            if(child.gameObject.GetComponent<CinematicLookAtPlayer>() != null)
            {
                child.gameObject.GetComponent<CinematicLookAtPlayer>().canLook = true;
            }
            Invoke("ResetCamera", 2);
        }
        //fakeHorde.SetActive(false);
    }

    void ResetCamera()
    {
       

        playerCamera.SetActive(true); //turn player camera on
        player.GetComponent<PlayerMovement>().canMove = true; //player can move

        fakeHorde.SetActive(false);
        realHorde.SetActive(true);

        this.gameObject.SetActive(false); //turn off this camera
    }
}
