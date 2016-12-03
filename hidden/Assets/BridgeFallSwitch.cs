using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerDetector))]
public class BridgeFallSwitch : MonoBehaviour
{
    public KeyCode triggerCode = KeyCode.E;
    public List<GameObject> linkedItems;

    void OnPlayerStay(Collider c)
    {
        if (Input.GetKeyDown(triggerCode))
            foreach (var i in linkedItems)
            {
                i.AddComponent<Rigidbody>();
            }
    }
}
