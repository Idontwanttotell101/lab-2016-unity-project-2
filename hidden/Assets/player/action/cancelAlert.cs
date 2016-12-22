//using UnityEngine;
//using System.Collections.Generic;

//public class cancelAlert : MonoBehaviour {

//    public List<GameObject> enemies;
//    GameObject GM;

//    void Awake() {
//        GM = GameObject.Find("_GM");
//    }

//    void cancelAllSearch() {
//        var objs = enemies;

//        foreach (var obj in objs)
//        {
//            obj.GetComponent<guardalert>().alertValue=0;
//            obj.GetComponent<guardalert>().alert = false;
//            obj.GetComponent<guardMove>().NextOne();
//        }
//    }

//    void OnTriggerEnter(Collider c) {
//        if(c.tag == "Player")
//        {
//            GM.GetComponent<status>().atSafeZone = true;
//            GM.GetComponent<status>().cankill = false;
//            cancelAllSearch();
//        }
//    }

//    void OnTriggerExit(Collider c) {
//        if (c.tag == "Player") {
//            GM.GetComponent<status>().atSafeZone = false;
//            GM.GetComponent<status>().cankill = true;
//        }
//    }
//}
