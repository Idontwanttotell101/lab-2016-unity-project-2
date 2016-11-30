using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class guardView : MonoBehaviour
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
        var delta = c.transform.position - transform.position;
        var vangle = Mathf.Abs(delta.y / new Vector2(delta.x, delta.z).magnitude);
        if (vangle > 0.4) return;
        delta.y = 0;
        var hangle = Mathf.Abs(Vector3.Angle(transform.forward, delta));
        if (hangle > 60) return;
        else OnGuardSeeYou.Invoke();
    }
}
