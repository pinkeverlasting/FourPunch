using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNozzleDetect : MonoBehaviour
{
    private GameObject backpackObject;
    // Use this for initialization
    void Start()
    {
        //backpackObject = GameObject.Find("Backpack");
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    private void OnTriggerEnter(Collider other) //detect objects that enter warp trigger
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ammo") //if an ammo or cat enters the trigger
        {
            Debug.Log("Ammo @ Nozzle"); //log that something has entered
            Destroy(other.gameObject);
           //other.gameObject.transform.position = backpackObject.transform.position;
           //other.gameObject.transform.SetParent(backpackObject.transform);
           // other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
           // other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
            //other.gameObject.GetComponent<Collider>().isTrigger = true;

        }
    }
}
