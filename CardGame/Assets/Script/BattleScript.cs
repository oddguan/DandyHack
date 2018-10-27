using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BattleScript : MonoBehaviour
{
	public Button BacktoMain;
    public Button PressToFight;
    public Slider PlayerHealthBar;
    public Slider EnemyHealthBar;
    public Sprite[] othersprites;

	// Use this for initialization
	void Start()
	{
		BacktoMain.onClick.AddListener(BackToMainSwitch);
        PressToFight.onClick.AddListener(Count);
	}

	void BackToMainSwitch()
	{
		//Output this to console when Button1 or Button3 is clicked
		SceneManager.LoadScene("Main");
		Debug.Log("Loaded Main Scene");
	}

    void Count(){
        
    }

	// Update is called once per frame
	void Update()
	{

	}
}
