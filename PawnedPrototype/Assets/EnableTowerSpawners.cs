using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTowerSpawners : MonoBehaviour {
    public GameObject mSpawner1, mSpawner2, mSpawner3;
    public GameObject overviewCamera;
	// Use this for initialization
	void Start () {
        mSpawner1.SetActive(false);
        mSpawner2.SetActive(false);
        mSpawner3.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" && !overviewCamera.activeSelf)
        {
            Debug.Log("activating spawners");
            mSpawner1.SetActive(true);
            mSpawner2.SetActive(true);
            mSpawner3.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
