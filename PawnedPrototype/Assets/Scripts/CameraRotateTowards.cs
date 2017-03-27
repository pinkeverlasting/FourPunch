using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateTowards : MonoBehaviour {

    public GameObject playerCamera;

    public GameObject player;

    public Transform target;
    float speed;

    Vector3 oldDir;

	// Use this for initialization
	void Start () {
        speed = 0.5f;
        oldDir = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetDir = target.position - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        if (oldDir == newDir)
        {
            // Debug.Log("Entered Destination");
            Invoke("ResetPlayer", 3);

        }
        else
        {
            transform.rotation = Quaternion.LookRotation(newDir);
        }

        oldDir = newDir;
       

	}

    void ResetPlayer()
    {
        playerCamera.SetActive(true); //turn player camera on
        player.GetComponent<PlayerMovement>().canMove = true; //player can move
        this.gameObject.SetActive(false); //turn off this camera
    }
}
