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
    public Button YouWinBack;
    public Button YouLoseBack;
    public GameObject YouWinGameUI;
    public GameObject YouLoseGameUI;
    public Slider PlayerHealthBar;
    public Slider EnemyHealthBar;
	public double PlayerHealth = 12000;
	public double PlayerAttack = 1100;
	public double EnemyHealth = 10000;
	public double EnemyAttack = 1000;
    public static double EnemycurrentHealth;
    public static double PlayercurrentHealth;
    float enemyhealthratio = 1.0f;
    float playerhealthratio = 1.0f;
    bool continuetofight = true;

	// Use this for initialization
	void Start()
	{
		BacktoMain.onClick.AddListener(BackToMainSwitch);
        PressToFight.onClick.AddListener(Count);
        YouWinBack.onClick.AddListener(BackToMainSwitch);
        YouLoseBack.onClick.AddListener(BackToMainSwitch);
        EnemycurrentHealth = EnemyHealth;
        PlayercurrentHealth = PlayerHealth;
	}

	void BackToMainSwitch()
	{
		//Output this to console when Button1 or Button3 is clicked
		SceneManager.LoadScene("Main");
		Debug.Log("Loaded Main Scene");
	}

    void Count(){
        if (continuetofight)
        {
            PlayercurrentHealth = PlayercurrentHealth - EnemyAttack;
            EnemycurrentHealth = EnemycurrentHealth - PlayerAttack;
        }
    }

	// Update is called once per frame
	void Update()
	{
        float enemyhealthratio = (float)(PlayercurrentHealth / PlayerHealth);
        float playerhealthratio = (float)(EnemycurrentHealth/EnemyHealth);
        EnemyHealthBar.value = enemyhealthratio;
        PlayerHealthBar.value = playerhealthratio;
        if (enemyhealthratio <= 0.0f){
            Debug.Log("You WIN");
            continuetofight = false;
            YouWinGameUI.SetActive(true);
        }
        if (playerhealthratio <= 0.0f ){
			Debug.Log("You LOSE, try again");
			continuetofight = false;
            YouLoseGameUI.SetActive(true);
        }

	}
}
