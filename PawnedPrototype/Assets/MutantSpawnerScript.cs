using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantSpawnerScript : MonoBehaviour
{

    public GameObject mutant;

    public float minRange, maxRange;

    float targetTimer;
    float timer;

    // Use this for initialization
    void Start()
    {
        targetTimer = Random.Range(minRange, maxRange);
        Invoke("IncreaseChallenge", 40);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= targetTimer)
        {
            SpawnMutant();
            timer = 0;
        }
    }

    void SpawnMutant()
    {
        Instantiate(mutant, transform.position, Quaternion.identity);
        targetTimer = Random.Range(minRange + 1, maxRange);
    }

    void IncreaseChallenge()
    {
        maxRange = maxRange - minRange;
        Invoke("IncreaseChallenge2", 50);
    }

    void IncreaseChallenge2()
    {
        maxRange = maxRange - 5;
        if(maxRange == 5)
        {
            maxRange = 6;
        }
    }
}
