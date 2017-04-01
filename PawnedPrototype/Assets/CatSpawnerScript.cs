using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawnerScript : MonoBehaviour {

    public GameObject redCat, blueCat, yellowCat;

    int catNumber;
    float targetTimer;
    float timer;

	// Use this for initialization
	void Start () {
        targetTimer = Random.Range(15,30);
		
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer + Time.deltaTime;
        if(timer >= targetTimer)
        {
            SpawnCat();
            timer = 0;
        }
	}

    void SpawnCat()
    {
        catNumber = Random.Range(1,3);
        if(catNumber == 1)
        {
            Instantiate(redCat, transform.position, Quaternion.identity);
        }
        else if (catNumber == 2)
        {
            Instantiate(blueCat, transform.position, Quaternion.identity);
        }
        else if (catNumber == 3)
        {
            Instantiate(yellowCat, transform.position, Quaternion.identity);
        }
        targetTimer = Random.Range(15, 30);
    }
}
