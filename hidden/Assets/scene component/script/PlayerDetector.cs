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
    public const string PlayerStayMessage = "OnPlayerStay";
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
        //StartCoroutine("PlayerStayCaster",c); doesn't work...?
        StartCoroutine(PlayerStayCaster(c));
        SendMessage(PlayerEnterMessage, c, SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerExit(Collider c)
    {
        if (!IsPlayer(c))
            return;
        PlayerLeave.Invoke();
        // StopCoroutine("PlayerStayCaster");
        StopAllCoroutines();
        SendMessage(PlayerLeaveMessage, c, SendMessageOptions.DontRequireReceiver);
    }

    IEnumerator PlayerStayCaster(Collider player)
    {
        while (true)
        {
            SendMessage(PlayerStayMessage, player, SendMessageOptions.DontRequireReceiver);
            yield return null;
        }
    }
}
