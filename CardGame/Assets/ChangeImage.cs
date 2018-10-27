using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class ChangeImage : MonoBehaviour {

    public Sprite spLeft;
    public Sprite spRight;
    public Sprite spMiddle;
    public Button PressToFight;

	// Use this for initialization
	void Start () {
		PressToFight.onClick.AddListener(Count);
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = othersprites[1];
	}

	void Count()
	{
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = othersprites[2];   
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
            this.GetComponent<SpriteRenderer>().sprite = spLeft;
		if (Input.GetKey(KeyCode.S))
            this.GetComponent<SpriteRenderer>().sprite = spRight;
		if (Input.GetKey(KeyCode.D))
            this.GetComponent<SpriteRenderer>().sprite = spMiddle;
	}
}
