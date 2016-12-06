using UnityEngine;
using System.Collections;

public class getsecret : MonoBehaviour {

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
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<statement>().gotSecret = true;
            }
        }
    }
}
