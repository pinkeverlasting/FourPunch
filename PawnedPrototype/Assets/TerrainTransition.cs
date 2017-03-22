using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTransition : MonoBehaviour {

    public GameObject terrain1, terrain2, level1Obj, level2Obj;

    public bool reTransition;
    // Use this for initialization
    private void Awake()
    {
        terrain1.SetActive(true);
        terrain2.SetActive(false);

        level1Obj.SetActive(true);
        level2Obj.SetActive(false);
    }

    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!reTransition)
            {
                terrain1.SetActive(false);
                terrain2.SetActive(true);

                level1Obj.SetActive(false);
                level2Obj.SetActive(true);
            }
            else
            {
                terrain1.SetActive(true);
                terrain2.SetActive(false);

                level1Obj.SetActive(true);
                level2Obj.SetActive(false);
            }
           
        }
    }
}
