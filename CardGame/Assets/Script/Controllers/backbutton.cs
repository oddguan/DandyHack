using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class backbutton : MonoBehaviour {

    public Button backbuttonss;

	// Use this for initialization
	void Start () {
        backbuttonss.onClick.AddListener(BackToMainSwitch);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void BackToMainSwitch()
	{
		//Output this to console when Button1 or Button3 is clicked
		SceneManager.LoadScene("Main");
		Debug.Log("Loaded Main Scene");
	}
}
