using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class status : MonoBehaviour {

    public Text text;
    public Text text2;
    public int ammo = 0;
    public bool gotSecret = false;
    public float alertRate = 0;
    public bool atSafeZone = false;
    public bool cankill { get; set; }

    void Start() {
        cankill = true;
    }

	void Update () {
        text.text = "ammo:" + ammo.ToString();
        text2.text = "alert rate : " + alertRate.ToString();
    }
}
