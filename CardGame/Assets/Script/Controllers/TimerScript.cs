using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	[SerializeField] private Text uiText;
	[SerializeField] private float mainTimer;
	[SerializeField] private Text Opportunity;
	private float timer;	
	private bool canCount = true;
	private bool doOnce = false;
	private string toBeDisplay;
	// Use this for initialization
	private int currentOpportunity;

	void Start() {
		currentOpportunity = PlayerPrefs.GetInt("currentOpportunity", 5);
		timer = mainTimer;
		toBeDisplay = currentOpportunity.ToString()+"/5";
		Opportunity.text = toBeDisplay;
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
				Opportunity.text = currentOpportunity.ToString();
				
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
		currentOpportunity--;
		PlayerPrefs.SetInt("currentOpportunity", currentOpportunity);
		toBeDisplay = currentOpportunity.ToString()+"/5";
		Opportunity.text = toBeDisplay;
	}
}
