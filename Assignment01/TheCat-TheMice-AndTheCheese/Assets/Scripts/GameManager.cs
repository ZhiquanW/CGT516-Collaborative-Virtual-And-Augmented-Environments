using System;
using System.Collections;
using System.Collections.Generic;
using  UnityEngine.UI;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour {

	public Text message;

	public bool isGameEnd;

	public bool isWin;

	static public GameManager instance;

	private void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		if (isGameEnd) {
			Time.timeScale = 0;
			if (isWin) {
				message.text = "WIN";
			}
			else {
				message.text = "WASTED";
			}
		}
	}
}
