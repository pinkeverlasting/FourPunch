using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("ChangeScene", 7);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeScene()
    {
        Application.LoadLevel(2);
    }
}
