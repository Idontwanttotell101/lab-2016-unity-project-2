using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TriggerLeaveDetector : MonoBehaviour
{
    private bool inside = false;
    private int counter = 0;
    [SerializeField]
    [Tooltip("Number of frame acceptable for no trigger")]
    private int ThresholdFrame = 5;

    [System.Serializable]
    public class GroundLeaveEvent : UnityEvent
    {
    }

    public GroundLeaveEvent OnGroundLeave;
    public const string GroundLeaveMessage = "OnGroundLeave";

    void Update()
    {
        if (inside) { counter = 0; return; }
        ++counter;
        if (counter > ThresholdFrame) OnGroundLeave.Invoke();
        SendMessage(GroundLeaveMessage);
    }

    void OnTriggerStay(Collider c)
    {
        inside = true;
    }
}
