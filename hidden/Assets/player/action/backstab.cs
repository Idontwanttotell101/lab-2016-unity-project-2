using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class backstab : MonoBehaviour
{
    [System.Serializable]
    public class OnGuardSeeYouEvent : UnityEvent { }

    public OnGuardSeeYouEvent OnGuardSeeYou;
    status GM;

    void Awake() {
        GM = GameObject.FindObjectOfType<status>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider c)
    {
        if (c.tag == "EnemyBack")
        {
			if (Input.GetMouseButtonDown (0) && GM.cankill) {
                Debug.Log("kill");
				Destroy (c.transform.parent.gameObject);
			}
        }
    }
}
