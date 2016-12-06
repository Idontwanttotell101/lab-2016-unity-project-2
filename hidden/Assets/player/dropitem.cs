using UnityEngine;
using System.Collections;

public class dropitem : MonoBehaviour {

	public GameObject dropItem;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void DropItem(){
		if (dropItem != null) 
		{
			Instantiate (dropItem, transform.position, transform.rotation);
		}
	}
}
