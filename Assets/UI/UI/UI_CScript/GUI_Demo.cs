using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;


public class GUI_Demo : MonoBehaviour {

	public GUISkin guiSkin;
    
    private AudioSource audioSrc;

    private float musicVolume = 0f;
    Rect windowRect = new Rect (0, 0, 400, 210);
	//string toggleTxt;
	string stringtxt = "Volume";
    Scene scene;

	//string textToEdit = "TextBox:\nHello World\nI've got few lines...";
    float hSliderValue = 1.0f;
	float vSliderValue = 0.0f;
	float hSbarValue;
	float vSbarValue;
	private List<GameObject> dundestory;
	Vector2 scrollPosition = Vector2.zero;


	void Start ()
	{
		dundestory = dunDestroy2._ddolObjects;
		audioSrc = dundestory.Find((x)=>x.name == "BackgroundMusic").GetComponent<AudioSource>();
		windowRect.x = (Screen.width - windowRect.width)/2;
		windowRect.y = (Screen.height - windowRect.height)/2;
		scene = SceneManager.GetActiveScene();
    }




	void OnGUI () 
	{
		GUI.skin = guiSkin;
        
		windowRect = GUI.Window (0, windowRect, DoMyWindow, "");
        

    }



	void DoMyWindow (int windowID) 
	{
       
    {
        
    }
        
        if (GUI.Button(new Rect(10, 20, 80, 20), "Home"))
        {
            SceneManager.LoadScene("MainMenuScene");
            Destroy(this);
            

        }
        

        GUI.Label(new Rect(60, 80, 80, 20), stringtxt);
        //stringToEdit = GUI.TextField (new Rect (15, 140, 110, 20), stringToEdit, 25);
        
        hSliderValue = GUI.HorizontalSlider (new Rect (150, 80, 200, 30), GlobalOptions.volume, 0.0f, 1.0f);
        musicVolume = hSliderValue;
        GlobalOptions.volume = musicVolume;
        vSliderValue = GUI.VerticalSlider (new Rect (380, 40, 50, 150), vSliderValue, 100.0f, 0.0f);
     
        


        //toggleTxt = GUI.TextField(new Rect(165, 50, 100, 30), toggleTxt, "A Toggle text");
        //textToEdit = GUI.TextArea (new Rect (165, 90, 185, 100), textToEdit, 200);

        GUI.Label (new Rect (180, 215, 100, 20), "ScrollView");
		scrollPosition = GUI.BeginScrollView (new Rect (180,235,160,100), scrollPosition, new Rect (0, 0, 220, 200));
		GUI.Button (new Rect (0,10,100,20), "Top-left");
		GUI.Button (new Rect (120,10,100,20), "Top-right");
		GUI.Button (new Rect (0,170,100,20), "Bottom-left");
		GUI.Button (new Rect (120,170,100,20), "Bottom-right");
		GUI.EndScrollView ();


		//hSbarValue = GUI.HorizontalScrollbar (new Rect (10, 360, 360, 30), hSbarValue, 5.0f, 0.0f, 10.0f);
		//vSbarValue = GUI.VerticalScrollbar(new Rect (380, 25, 30, 200), vSbarValue, 1.0f, 30.0f, 0.0f);


		//GUI.DragWindow (new Rect (0,0,10000,10000));
	}

    void Update()
    {
        audioSrc.volume = musicVolume;
    }





}
