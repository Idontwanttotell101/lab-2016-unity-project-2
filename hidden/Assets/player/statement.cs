﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class statement : MonoBehaviour {

    public Text text;
    public Text text2;
    public int ammo = 0;
    public bool gotSecret = false;
    public float alertRate = 0;
	
	// Update is called once per frame
	void Update () {
        text.text = "ammo:" + ammo.ToString();
        text2.text = "alert rate : " + alertRate.ToString();
    }
}
