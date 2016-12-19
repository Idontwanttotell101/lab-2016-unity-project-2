using UnityEngine;
using System.Collections;

public class NavTarget : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

	}

    public void TrackPlayer() {
        GetComponent<NavMeshAgent>().destination = GameObject.Find("Player").transform.position;
    }
}
