using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainControl : MonoBehaviour {
    public int Counter;
    public GameObject hand;
    public Button DrawaCard;
    public Button Collection;
    public Button InitiateBattle;

	// Use this for initialization
	void Start () {
        DrawaCard.onClick.AddListener(SwitchtoDrawaCard);
        Collection.onClick.AddListener(SwitchtoCollection);
        InitiateBattle.onClick.AddListener(SwitchtoBattle);
	}

	void SwitchtoDrawaCard()
	{
		//Output this to console when Button1 or Button3 is clicked
        SceneManager.LoadScene("DrawaCard");

		Debug.Log("You have clicked the button DrawaCard");
	}

	void SwitchtoCollection()
	{
		//Output this to console when Button1 or Button3 is clicked
		Debug.Log("You have clicked the button Collection");
	}

	void SwitchtoBattle()
	{
        //Output this to console when Button1 or Button3 is clicked
        SceneManager.LoadScene("Battle");
		Debug.Log("You have clicked the button Battle");
	}

	// Update is called once per frame
	void Update () {
        
	}
}
