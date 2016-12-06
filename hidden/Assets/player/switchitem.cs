using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class switchitem : MonoBehaviour {

	string currentActItem;
	List<string> items;

	void Awake()
	{
		items = new List<string>(){"knife","pistol"};
		CurrentItem ("knife");
	}

	void Start () 
	{
		
	}
	

	void Update () 
	{
		if (Input.GetKey (KeyCode.Alpha1)) {
			if (GetComponent<items> ().haveKnife == true) 
			{
				CurrentItem ("knife");
			}
		}
		if (Input.GetKey (KeyCode.Alpha2)) {
			if (GetComponent<items> ().havePistol == true) 
			{
				CurrentItem ("pistol");
			}
		}
	}

	public void CurrentItem(string needtoactive)
	{
		if (needtoactive == currentActItem) {
		} 
		else 
		{
			currentActItem = needtoactive;
			foreach (string element in items) 
			{
				transform.Find (element).gameObject.SetActive (false);
			}
			transform.Find (needtoactive).gameObject.SetActive (true);
		}
	}
}
