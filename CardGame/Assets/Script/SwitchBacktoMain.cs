using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SwitchBacktoMain : MonoBehaviour {
    public Button BacktoMain;

	// Use this for initialization
	void Start () {
        BacktoMain.onClick.AddListener(BackToMainSwitch);
	}

	void BackToMainSwitch()
	{
		//Output this to console when Button1 or Button3 is clicked
		SceneManager.LoadScene("Main");
		Debug.Log("Loaded Main Scene");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
