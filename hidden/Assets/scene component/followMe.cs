using UnityEngine;
using System.Collections;

public class followMe : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        FindObjectOfType<NavMeshAgent>().destination = this.transform.position;
	}
}
