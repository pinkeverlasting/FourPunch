using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour {

    public GameObject immuneMutant;
    public GameObject mutant1, mutant2, mutant3, mutant4, mutant5, mutant6;
    private GameObject barrier;
	// Use this for initialization
	void Start () {
        immuneMutant.SetActive(false);
        barrier = GameObject.Find("BossFightBarrier");
	}
	
	// Update is called once per frame
	void Update () {
		if (mutant1.GetComponent<EnemyStatePattern>().enabled == false 
            && mutant2.GetComponent<EnemyStatePattern>().enabled == false 
            && mutant3.GetComponent<EnemyStatePattern>().enabled == false 
            && mutant4.GetComponent<EnemyStatePattern>().enabled == false
            && mutant5.GetComponent<EnemyStatePattern>().enabled == false
            && mutant6.GetComponent<EnemyStatePattern>().enabled == false)
        {
            //Debug.Log("behavior is dead");
            immuneMutant.SetActive(true);
        }
        if(immuneMutant.GetComponent<EnemyStatePattern>().enabled == false)
        {
            Destroy(barrier);
        }

    }
}
