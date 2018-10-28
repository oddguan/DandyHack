using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class MainControl : MonoBehaviour {
    public int Counter;
    public GameObject hand;
    public Button DrawaCard;
    public Button Collection;
    public Button InitiateBattle;
    public string fileName = "playerInventory";
    public string fileExtension = ".txt";

	// Use this for initialization
	void Start () {
        DrawaCard.onClick.AddListener(SwitchtoDrawaCard);
        Collection.onClick.AddListener(SwitchtoCollection);
        InitiateBattle.onClick.AddListener(SwitchtoBattle);
        //DeleteFile();
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
        SceneManager.LoadScene("MyCollection");
		Debug.Log("You have clicked the button Collection");
	}

	void SwitchtoBattle()
	{
        //Output this to console when Button1 or Button3 is clicked
        SceneManager.LoadScene("Battle");
		Debug.Log("You have clicked the button Battle");
	}
//	void DeleteFile()
//	{
//		string filePath = "Assets/Script/" + fileName + fileExtension;

//		// check if file exists
//		if (!File.Exists(filePath))
//		{
//			Debug.Log( "no " + fileName + " file exists" );
//		}
//		else
//		{
//			Debug.Log( fileName + " file exists, deleting..." );

//			File.Delete(filePath);

//			RefreshEditorProjectWindow();
//		}
//	}

//	void RefreshEditorProjectWindow()
//	{
//#if UNITY_EDITOR
//         UnityEditor.AssetDatabase.Refresh();
//#endif
	//}

	// Update is called once per frame
	void Update () {
        
	}
}
