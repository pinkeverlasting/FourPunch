using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour {

    public GameObject immuneMutant;
    public GameObject mutant1, mutant2, mutant3, mutant4, mutant5, mutant6;
    private GameObject barrier;

    public GameObject finalMutant1, finalMutant2, finalMutant3, finalMutant4, bossMutant1, bossMutant2;
    // Use this for initialization
    void Start () {
        immuneMutant.SetActive(false);
        barrier = GameObject.Find("BossFightBarrier");
	}
	
	// Update is called once per frame
	void Update () {
		if (mutant1.GetComponent<EnemyStatePattern>().enabled == false //if all mutants before boss area are dead
            && mutant2.GetComponent<EnemyStatePattern>().enabled == false 
            && mutant3.GetComponent<EnemyStatePattern>().enabled == false 
            && mutant4.GetComponent<EnemyStatePattern>().enabled == false
            && mutant5.GetComponent<EnemyStatePattern>().enabled == false
            && mutant6.GetComponent<EnemyStatePattern>().enabled == false)
        {
            //Debug.Log("behavior is dead");
            immuneMutant.SetActive(true); //spawn mini boss mutant
        }
        if(immuneMutant.GetComponent<EnemyStatePattern>().enabled == false)
        {
            Destroy(barrier); //if mutant is dead, get rid of barrier
        }

        if(finalMutant1.GetComponent<EnemyStatePattern>().enabled == false)
        {
            if (finalMutant2.GetComponent<EnemyStatePattern>().enabled == false)
            {
                if (finalMutant3.GetComponent<EnemyStatePattern>().enabled == false)
                {
                    if (finalMutant4.GetComponent<EnemyStatePattern>().enabled == false)
                    {
                        if (bossMutant1.GetComponent<EnemyStatePattern>().enabled == false && bossMutant2.GetComponent<EnemyStatePattern>().enabled == false)
                        {
                            Invoke("DoneLevel", 6); //if all boss area mutants are dead, change level
                        }

                    }
                    
                }

            }

        }

    }
    private void DoneLevel() //the level is done
    {
        Application.LoadLevel(5);
    }
}
