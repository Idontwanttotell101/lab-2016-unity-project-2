using UnityEngine;
using System.Collections;

public class grounded : MonoBehaviour {

    public GameObject Player;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider c)
    {
        Player.GetComponent<movement>().grounded = true;
    }
}
