using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    [System.Serializable]
    public class PlayerDetectedEvent : UnityEvent
    {
    }

    public PlayerDetectedEvent PlayerDetected;
    public PlayerDetectedEvent PlayerLeave;
    public string PlayerTag = "Player";
    public const string PlayerEnterMessage = "OnPlayerEnter";
    public const string PlayerLeaveMessage = "OnPlayerExit";
    public bool UseRoot = false;
    //public bool BroadcastPlayerEvent = false;

    private bool IsPlayer(Collider c)
    {
        return (!UseRoot && c.tag == PlayerTag)
            || (UseRoot && c.transform.root.tag == PlayerTag);
    }

    void OnTriggerEnter(Collider c)
    {
        if (!IsPlayer(c))
            return;
        PlayerDetected.Invoke();
        SendMessage(PlayerEnterMessage, c, SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerExit(Collider c)
    {
        if (!IsPlayer(c))
            return;
        PlayerLeave.Invoke();
        SendMessage(PlayerLeaveMessage, c, SendMessageOptions.DontRequireReceiver);
    }
}
