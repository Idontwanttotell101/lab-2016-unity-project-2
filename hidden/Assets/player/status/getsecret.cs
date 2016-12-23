using UnityEngine;
using System.Collections;

public class getsecret : MonoBehaviour {

    status GM;
	// Use this for initialization
	void Start () {
        GM = GameObject.FindObjectOfType<status>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider c)
    {
        if (c.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GM.gotSecret = true;
            }
        }
    }
}
