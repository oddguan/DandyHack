using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DONTDESTROY : MonoBehaviour {

	public string fileName = "playerInventory";
	public string fileExtension = ".txt";
    // Use this for initialization
    public Button toMainButton;

	void Awake()
	{
		this.InstantiateController();
        DeleteFile();
        toMainButton.onClick.AddListener(TOMAINMAINMAIN);
	}

    void TOMAINMAINMAIN(){
		SceneManager.LoadScene("Main");

	}

	private void InstantiateController()
	{
        Debug.Log("I dont need DontDestroyonLoad");
		//if (Instance == null)
		//{
		//	Instance = this;
		//	DontDestroyOnLoad(this);
		//}
		//else if (this != Instance)
		//{
		//	Destroy(this.gameObject);
		//}
	}

	void DeleteFile()
	{
		string filePath = "Assets/Script/" + fileName + fileExtension;

		// check if file exists
		if (!File.Exists(filePath))
		{
			Debug.Log("no " + fileName + " file exists");
		}
		else
		{
			Debug.Log(fileName + " file exists, deleting...");

			File.Delete(filePath);

			RefreshEditorProjectWindow();
		}
	}

	void RefreshEditorProjectWindow()
	{
#if UNITY_EDITOR
         UnityEditor.AssetDatabase.Refresh();
#endif
	}
}
