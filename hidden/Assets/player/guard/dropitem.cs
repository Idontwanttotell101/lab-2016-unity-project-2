using UnityEngine;
using System.Collections;

public class dropitem : MonoBehaviour {

	public GameObject dropItem;

    void OnDestroy() {
        Instantiate(dropItem, transform.position,new Quaternion());
    }
}
