﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceNumberTextScript : MonoBehaviour {


	TextMeshProUGUI text;
	// Text text;
	public static int diceNumber;

	// Use this for initialization
	void Start () {
		text = this.GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update () {
		text.text = diceNumber.ToString();
	}
}
