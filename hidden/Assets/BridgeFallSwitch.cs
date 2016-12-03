using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerDetector))]
public class BridgeFallSwitch : MonoBehaviour
{
    public KeyCode triggerCode = KeyCode.E;
    public List<GameObject> linkedItems;

    private List<GameObject> tracking = new List<GameObject>();

    void Update()
    {
        if (tracking.Count != 0 && Input.GetKeyDown(triggerCode))
            foreach (var i in linkedItems)
            {
                i.AddComponent<Rigidbody>();
            }
    }

    void OnPlayerEnter(Collider c)
    {
        tracking.Add(c.gameObject);
    }

    void OnPlayerExit(Collider c)
    {
        tracking.Remove(c.gameObject);
    }
}
