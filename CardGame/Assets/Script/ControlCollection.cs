using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;


public class ControlCollection : MonoBehaviour {

	[SerializeField] private Button backButton;
	[SerializeField] private Text attack1;
	[SerializeField] private Text attack2;
	[SerializeField] private Text attack3;
	[SerializeField] private Text attack4;
	[SerializeField] private Text attack5;
	[SerializeField] private Text attack6;
	[SerializeField] private Text attack7;
	[SerializeField] private Text attack8;
	[SerializeField] private Text attack9;
	[SerializeField] private Text attack10;
	[SerializeField] private Text hp1;
	[SerializeField] private Text hp2;
	[SerializeField] private Text hp3;
	[SerializeField] private Text hp4;
	[SerializeField] private Text hp5;
	[SerializeField] private Text hp6;
	[SerializeField] private Text hp7;
	[SerializeField] private Text hp8;
	[SerializeField] private Text hp9;
	[SerializeField] private Text hp10;
	
	[SerializeField] private Image image1;
	
	[SerializeField] private Image image2;
	 
	[SerializeField] private Image image3;
	
	[SerializeField] private Image image4;

	[SerializeField] private Image image5;
	
	[SerializeField] private Image image6;// Use this for initialization

	[SerializeField] private Image image7;

	[SerializeField] private Image image8;
	[SerializeField] private Image image9;
	[SerializeField] private Image image10;
	[SerializeField] private Image[] imageArray;
	[SerializeField] private Text[] attackArray;
	[SerializeField] private Text[] healthArray;
	void Start () {
		imageArray = new Image[] {image1, image2, image3, image4, image5, image6, image7, image8, image9, image10};
		attackArray = new Text[] {attack1, attack2, attack3, attack4, attack5, attack6, attack7, attack8, attack9, attack10};
		healthArray = new Text[] {hp1,hp2,hp3,hp4,hp5,hp6,hp7,hp8,hp9,hp10};
		string[] readArray = new string[10];	
		int i=0;
        backButton.onClick.AddListener(backtomain);
        string[] reads = new string[10];
		reads = File.ReadAllLines("Assets/Script/playerInventory.txt");
		foreach(string r in reads){
			readArray[i] = r;
			i++;
			Debug.Log(r);
		}
		Debug.Log(reads);
		for(int j=0;j<i;j++){
			string[] splitted = readArray[j].Split(',');
			imageArray[j].sprite =  Resources.Load <Sprite> (splitted[1]);
			Debug.Log(readArray[j]);
			attackArray[j].text = splitted[3];
			healthArray[j].text = splitted[4];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void backtomain(){
        Debug.Log("WTF");
        SceneManager.LoadScene("Main");
    }
}
