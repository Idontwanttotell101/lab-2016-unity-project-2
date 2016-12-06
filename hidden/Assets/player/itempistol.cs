using UnityEngine;
using System.Collections;

public class itempistol : MonoBehaviour {

	public GameObject Player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider c)
	{
		if (c.tag == "Player") 
		{
			if (Input.GetKeyDown (KeyCode.E)) 
			{
				Player.GetComponent<items>().havePistol = true;
				Player.GetComponent<switchitem> ().CurrentItem ("pistol");
				Player.GetComponent<statement>().ammo += 3;
				Destroy (gameObject);
			}
		}
	}
}
