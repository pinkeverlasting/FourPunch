using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour {

    private bool isFading;

    public bool menuScreen;

    public Texture2D fadeTexture;
    float fadeSpeed;
    //int drawDepth;
    public float alpha;
    public int fadeDirection;

    private void Awake()
    {
        fadeSpeed = 5f;
       // drawDepth = -1000;
        //alpha = 0f;
       // fadeDirection = 1;

        isFading = false;
    }

    // Use this for initialization
    void Start () {
        if (menuScreen == false)
        {
          Fade();
        }


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            //isFading = true;
        }

        if(alpha == 1 && menuScreen)
        {
            Application.LoadLevel(1);
        }
	}
    private void OnGUI()
    {
        if (isFading)
        {
            //Fade();

           // Color thisAlpha = GUI.color;
           // thisAlpha.a = alpha;

           // GUI.depth = drawDepth;

           // GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

            alpha = Mathf.Clamp01(alpha + fadeDirection* (Time.deltaTime / fadeSpeed));
            GUI.color = new Color(alpha, alpha, alpha, alpha);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
            //Debug.Log(alpha);
        }
        
    }

    public void Fade()
    {
        isFading = true;
       // OnGUI();
        //Debug.Log(isFading);
        

    }

    public float GetAlpha()
    {
        return alpha;
    }
}
