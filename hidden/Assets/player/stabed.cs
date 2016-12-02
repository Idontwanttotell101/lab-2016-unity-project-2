using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class stabed : MonoBehaviour
{
    [System.Serializable]
    public class OnGuardSeeYouEvent : UnityEvent { }

    public OnGuardSeeYouEvent OnGuardSeeYou;

    void Start()
    {
        OnGuardSeeYou.AddListener(() => Debug.Log("see"));
    }

    // Update is called once per frame
    void OnTriggerStay(Collider c)
    {
        if (c.tag == "Player")
        {
            var delta = c.transform.position - transform.position; //direction of collider to player
            var vangle = Mathf.Abs(delta.y / new Vector2(delta.x, delta.z).magnitude);
            if (vangle > 0.4) return;
            delta.y = 0;
            var hangle = Mathf.Abs(Vector3.Angle(-transform.forward, delta));
            if (hangle > 15) return;
            else OnGuardSeeYou.Invoke();
        }
    }
}
