﻿using UnityEngine;
using UnityEngine.UI;

public class CountDisp : MonoBehaviour {

    Text text;
	
	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	void Update ()
    {
        text.text = "MoveCount : " + PlayerController.moveCount;
	}
}