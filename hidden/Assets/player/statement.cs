using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class statement : MonoBehaviour {

    public Text text;
    public int ammo = 0;
    public bool gotSecret = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "ammo:" + ammo.ToString();
    }
}
