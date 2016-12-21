using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class backstab : MonoBehaviour
{
    [System.Serializable]
    public class OnGuardSeeYouEvent : UnityEvent { }

    public OnGuardSeeYouEvent OnGuardSeeYou;

    // Update is called once per frame
    void OnTriggerStay(Collider c)
    {
        if (c.tag == "EnemyBack")
        {
			if (Input.GetMouseButtonDown (0)) {
				Destroy (c.transform.parent.gameObject);
			}
        }
    }
}
