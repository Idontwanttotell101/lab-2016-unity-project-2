using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerDetector))]
public class GenericButton : MonoBehaviour
{
    public KeyCode triggerCode = KeyCode.E;
    public PlayerDetector.PlayerDetectedEvent OnPlayerPushThis;

    void OnPlayerStay(Collider c)
    {
        if (Input.GetKeyDown(triggerCode))
            OnPlayerPushThis.Invoke();
    }
}
