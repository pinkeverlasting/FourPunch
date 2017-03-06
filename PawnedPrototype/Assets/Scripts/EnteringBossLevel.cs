using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringBossLevel : MonoBehaviour {

    public GameObject explosiveWall;
    public Transform explosionLocation;
    public GameObject bossMutantContainer;
    public GameObject mutantContainer;

    public GameObject cinematicCamera;
    public GameObject playerCamera;

    private GameObject player;
	// Use this for initialization
	void Start () {
        bossMutantContainer.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            player = other.gameObject;

            cinematicCamera.SetActive(true);
            playerCamera.SetActive(false);
            player.GetComponent<PlayerMovement>().canMove = false;

            foreach (Transform child in mutantContainer.transform) //USE THIS FOR CUTSCENE
            {
                if (child.gameObject.tag == "Mutant")
                {
                    child.GetComponent<EnemyStatePattern>().move = false;
                }
            }

            foreach (Transform child in explosiveWall.transform)
            {
                Rigidbody rb = child.GetComponent<Rigidbody>();

                rb.isKinematic = false;

                rb.AddExplosionForce(1000, explosionLocation.position, 40, 1f);

            }
            Invoke("ExplodeEnd", 5);

            this.GetComponent<Collider>().enabled = false;
            //this.gameObject.SetActive(false);
        }

        
     }

    void ExplodeEnd()
    {
        Debug.Log("Entered Explosion End");

        cinematicCamera.SetActive(false);
        playerCamera.SetActive(true);
       player.GetComponent<PlayerMovement>().canMove = true;

        foreach (Transform child in mutantContainer.transform) //USE THIS FOR CUTSCENE
        {
            if (child.gameObject.tag == "Mutant")
            {
                child.GetComponent<EnemyStatePattern>().move = true;
            }
        }

        foreach (Transform child in explosiveWall.transform) //SPAWN BOSSES AFTER EXPLOSION
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();

            rb.isKinematic = true;
            child.GetComponent<Collider>().enabled = false;

           // rb.AddExplosionForce(500, explosionLocation.position, 7, 6f);

        }
        this.GetComponent<Collider>().enabled = false;

        bossMutantContainer.SetActive(true);

        explosiveWall.GetComponent<Collider>().enabled = true;

        Invoke("ClearExplosion", 6);
    }

    void ClearExplosion()
    {
        foreach (Transform child in explosiveWall.transform)
        {
            Destroy(child.gameObject);

        }
        
    }
}
