using UnityEngine;
using System.Collections;

public class items : MonoBehaviour {

	public bool haveKnife = true;

	public bool havePistol = false;

    public void PickUpPistol() {
        havePistol = true;

    }

}
