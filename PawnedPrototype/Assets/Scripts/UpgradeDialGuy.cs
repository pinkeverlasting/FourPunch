using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDialGuy : MonoBehaviour
{

    public GameObject dialText;
    public Text text;

    private GameObject parent;

    public Collider playerStopper;
    public GameObject gunUpgrade;

    int textNumber;


    // Use this for initialization
    void Start()
    {
        parent = this.transform.parent.gameObject;
        textNumber = 0;
        dialText.SetActive(false);
        parent.GetComponent<MoveBridge>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (textNumber > 5)
        {
            EndConversation();
        }

        switch (textNumber)
        {
            case 0:
                text.text = "Thank you for saving us back there!";
                break;
            case 1:
                text.text = "Here! Let me install this gun upgrade!";
                break;
            case 2:
                text.text = "Done! Now you can combine cats!";
                gunUpgrade.SetActive(false);
                break;
            case 3:
                text.text = "When sucking, keep holding the button..";
                break;
            case 4:
                text.text = "..to capture two cats!";
                break;
            case 5:
                text.text = "Good luck! Have fun!";
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //if player approaches, show text
        {
            dialText.SetActive(true);
            //Invoke("StopDial", 15);
        }
    }
    private void OnTriggerExit(Collider other) //turns off text if you leave
    {
        if (other.gameObject.tag == "Player")
        {
            dialText.SetActive(false);

        }
    }
    private void StopDial() //turns off text if you stay too long
    {
        dialText.SetActive(false);
    }

    public void OnClickRight()
    {
        textNumber += 1;
    }
    public void OnClickLeft()
    {
        textNumber -= 1;
    }
    private void EndConversation()
    {
        StopDial();
        playerStopper.enabled = false;
        parent.GetComponent<MoveBridge>().enabled = true;

    }
}
