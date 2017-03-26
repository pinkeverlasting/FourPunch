using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringBossLevel : MonoBehaviour {

    public GameObject explosiveWall;
    public GameObject explosionObject;
    private Transform explosionLocation;
    public GameObject bossMutantContainer;
    public GameObject mutantContainer;

    public GameObject cinematicCamera;
    public GameObject playerCamera;

    private GameObject player;
	// Use this for initialization
	void Start () {
        bossMutantContainer.SetActive(false);
        explosionLocation = explosionObject.transform;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //if player enters boss area, turn cinematic camera on and turn off player camera and tell all mutants to not move.
        {
            
           

            cinematicCamera.SetActive(true);
            playerCamera.SetActive(false);
            player.GetComponent<PlayerMovement>().canMove = false;

            foreach (Transform child in mutantContainer.transform) //USE THIS FOR CUTSCENE
            {
                if (child.gameObject.tag == "Mutant")
                {
                    child.GetComponent<EnemyStatePattern>().move = false; //all mutants can't move
                }
            }

            foreach (Transform child in explosiveWall.transform) //grab all wall pieces and tell them to explode
            {
                Rigidbody rb = child.GetComponent<Rigidbody>();

                rb.isKinematic = false;

                rb.AddExplosionForce(1000, explosionLocation.position, 40, 1f);

            }
            Invoke("ExplodeEnd", 5); //countdown to call an end to explosion

            this.GetComponent<Collider>().enabled = false; //don't detect player presense anymore
            //this.gameObject.SetActive(false);
        }

        
     }

    void ExplodeEnd() //to end the explosion
    {
        Debug.Log("Entered Explosion End");

        cinematicCamera.SetActive(false); //set cameras back to what they were and tell mutants to move
        playerCamera.SetActive(true);
       player.GetComponent<PlayerMovement>().canMove = true;

        foreach (Transform t in mutantContainer.transform) //USE THIS FOR CUTSCENE
        {
            if (t.gameObject.tag == "Mutant")
            {
                t.GetComponent<EnemyStatePattern>().move = true; //mutants can move now
            }
        }

        foreach (Transform e in explosiveWall.transform) //SPAWN BOSSES AFTER EXPLOSION
        {
            Rigidbody rb = e.GetComponent<Rigidbody>();

            rb.isKinematic = true;
            e.GetComponent<Collider>().enabled = false;

           // rb.AddExplosionForce(500, explosionLocation.position, 7, 6f);

        }

        this.GetComponent<Collider>().enabled = false;

       bossMutantContainer.SetActive(true); //spawn boss mutants

       explosiveWall.GetComponent<Collider>().enabled = true; //don't let player go outside the wall

       Invoke("ClearExplosion", 6); //clear the debris
    }

    void ClearExplosion() //clears debris
    {
        foreach (Transform child in explosiveWall.transform)
        {
            Destroy(child.gameObject);

        }
        
    }
}
