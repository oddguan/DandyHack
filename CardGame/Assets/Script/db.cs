using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;
public class db : MonoBehaviour {
	private IDbConnection _dbc;
	private IDbCommand _dbcm;
	private IDataReader _dbr;
	// Use this for initialization
	private string _constr, sqlQuery;

	void Awake() {
		_constr="URI=file:" + Application.dataPath + "/Plugins/ExampleDatabase.db";;
		_dbc=new SqliteConnection(_constr);
		_dbc.Open();
	}
	void Start () {
		_dbcm=_dbc.CreateCommand();
		_dbcm.CommandText="SELECT * FROM `Example`";
		_dbr=_dbcm.ExecuteReader();
		// while(_dbr.Read()){
		// 	int ID = _dbr.GetInt32(0);
		// 	string Fname = _dbr.GetString(1);
		// 	string MI = _dbr.GetString(2);
		// 	string Lname = _dbr.GetString(3);
		// 	int Age = _dbr.GetInt32(4);
		// 	string output = string.Format("ID: {0}, Fname:{1}, Lname:{2}, Age:{3}", ID, Fname, Lname, Age);
		// 	Debug.Log(output);
		// }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void insertValue() {

	}

	private void deleteValue(int id) {
		using (_dbc = new SqliteConnection(_constr)){
			_dbc.Open();
			_dbcm = _dbc.CreateCommand();
			sqlQuery = string.Format("Delete from Example WHERE ID=\"{0}\"", id);
			_dbcm.CommandText = sqlQuery;
            _dbcm.ExecuteScalar();
            _dbc.Close();
		}
	}

}
