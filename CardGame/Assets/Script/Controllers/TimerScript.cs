using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.SqliteClient;
using System.IO;

public class TimerScript : MonoBehaviour {

	[SerializeField] private Text uiText;
	[SerializeField] private float mainTimer;
	[SerializeField] private Text Opportunity;
	[SerializeField] private Image Mascot;

	private float timer;	
	private bool canCount = true;
	private bool doOnce = false;
	private string toBeDisplay;
	// Use this for initialization
	private int currentOpportunity;

	private IDbConnection _dbc;
	private IDbCommand _dbcm;
	private IDataReader _dbr;
	// Use this for initialization
	private string _constr, sqlQuery;

	private System.Random rnd;
	private string outputFile;

	void Start() {
		currentOpportunity = PlayerPrefs.GetInt("currentOpportunity", 5);
		timer = mainTimer;
		toBeDisplay = currentOpportunity.ToString()+"/5";
		toBeDisplay = "You have " + toBeDisplay + " opportunities left";
		Opportunity.text = toBeDisplay;
		_constr="URI=file:" + Application.dataPath + "/Plugins/GameDB.db";
		_dbc=new SqliteConnection(_constr);
		_dbc.Open();
		writeRecord();
	}
	void Update() {
		if(timer>=0.0f && canCount) {
			timer-=Time.deltaTime;
			int seconds = (int)timer%60;
			int minutes = ((int)timer-seconds)/60;
			if(seconds>=10){
				toBeDisplay = string.Format("{0}:{1}",minutes,seconds);
			}
			else{
				toBeDisplay = string.Format("{0}:0{1}",minutes,seconds);
			}
			uiText.text = toBeDisplay;
		}

		else if(timer <= 0.0f && !doOnce) {
			if(currentOpportunity<5){
				currentOpportunity++;
				timer = 1800.0f;
				uiText.text = "30:00";
				toBeDisplay = currentOpportunity.ToString()+"/5";
				toBeDisplay = "You have " + toBeDisplay + " opportunities left";
				Opportunity.text = toBeDisplay;
			}
			else{
				canCount = false;
				doOnce = true;
				uiText.text = "00:00";
				timer = 0.0f;
			}
		}
	}

	public void Recruit() {
		if(currentOpportunity>0){
			currentOpportunity--;
			PlayerPrefs.SetInt("currentOpportunity", currentOpportunity);
			toBeDisplay = currentOpportunity.ToString()+"/5";
			toBeDisplay = "You have " + toBeDisplay + " opportunities left";
			Opportunity.text = toBeDisplay;
			SelectCard();
		}
		else{
			Opportunity.text = "No recruit opportunity left!";
		}
		
	}

	public void SelectCard() {
		string rarity;
        double rarity_number;
        rnd = new System.Random();
		rarity_number = rnd.NextDouble();
            // Debug.Log(rarity_number);
            if(rarity_number<=0.5){
                rarity = "N";
            }
            else if(rarity_number>0.5 && rarity_number<=0.8) {
                rarity="R";
            }
            else if(rarity_number>0.8 && rarity_number<=0.95) {
                rarity="SR";
            }
            else {
                rarity="SSR";
        }
		_dbcm=_dbc.CreateCommand();
		_dbcm.CommandText=string.Format("SELECT ID, Name, Attack, Health " +
			"FROM `CardBase`" + "WHERE Rarity = (" +
			"SELECT RarityID FROM `Possibility`"+
			"WHERE RarityName=\"{0}\")" +
			"ORDER BY RANDOM() LIMIT 1", rarity);
		_dbr=_dbcm.ExecuteReader();
		while(_dbr.Read()){
			int ID = _dbr.GetInt32(0);
			Debug.Log(ID);
		}
		
		// string Name = _dbr.GetString(1);
		// float Attack = _dbr.GetFloat(2);
		// float Health = _dbr.GetFloat(3);
		
		// Debug.Log(Name);
		// Debug.Log(Attack);
		// Debug.Log(Health);
	}

	public void writeRecord() {
		outputFile = "Assets/Script/playerInventory.txt";
		File.AppendAllText(outputFile,"Hello\nWorld\n");
	}
}
