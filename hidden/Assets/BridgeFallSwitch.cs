using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerDetector))]
public class BridgeFallSwitch : MonoBehaviour
{
    public KeyCode triggerCode = KeyCode.E;
    public List<GameObject> linkedItems;
    public OffMeshLink link;

    void OnPlayerStay(Collider c)
    {
        if (Input.GetKeyDown(triggerCode))
            Destroy(link);
            foreach (var i in linkedItems)
            {
                i.AddComponent<Rigidbody>();
                i.GetComponent<Collider>().enabled = false;
            }
    }
}
