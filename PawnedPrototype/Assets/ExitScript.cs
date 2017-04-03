using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

    public bool isMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenu)
            {
                Application.Quit();
            }
            else
            {
                Application.LoadLevel(0);
            }
        }
		
	}
}
