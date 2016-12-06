using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyfall : MonoBehaviour {

    int fall_countdown=5;
    void Update() {
        --fall_countdown;
        if (fall_countdown < 0) {
            //Destroy(this.transform.root.gameObject);
            this.transform.root.gameObject.AddComponent<Rigidbody>();
            this.transform.root.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            this.transform.root.gameObject.GetComponent<Collider>().enabled = false;
            enabled = false;
        }
    }

    void OnTriggerStay(Collider c) {
        //Debug.Log("Stay");
        fall_countdown = 10;
    }
}
