using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;
using System;
public class selectCard : MonoBehaviour {
    private IDbConnection _dbc;
	private IDbCommand _dbcm;
	private IDataReader _dbr;
	// Use this for initialization
	private string _constr, sqlQuery;
    private System.Random rnd;

    void Awake() {
		
	}
    void Start() {
        _constr="URI=file:" + Application.dataPath + "/Plugins/Game.db";;
		_dbc=new SqliteConnection(_constr);
		_dbc.Open();
        Debug.Log("Loaded database");
        String rarity;
        double rarity_number;
        rnd = new System.Random();
        /*
        If the random number generated is less than 0.5, it is a N card
        If between 0.5 and 0.8, it is a R card
        If between 0.8 and 0.95, it is a SR card
        If above 0.95, it is a SSR card
         */
        
        for(int i=0;i<5;i++){
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
            // Debug.Log(rarity);
            _dbcm=_dbc.CreateCommand();
		    _dbcm.CommandText=string.Format("SELECT ID, Name, Attack, Health " +
             "FROM `CardBase`" + "WHERE Rarity = (" +
             "SELECT RarityID FROM `Possibility`"+
             "WHERE RarityName=\"{0}\")" +
             "ORDER BY RANDOM() LIMIT 1", rarity);
		    _dbr=_dbcm.ExecuteReader();
            while(_dbr.Read()){
                Debug.Log(_dbr.GetString(1));
            }
        }
        
    }

    void Update() {

    }

    void loadDatabase() {
        
    }
    private double rng() {
        
        return rnd.NextDouble();
    }
}