using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerDetector))]
public class BridgeGenerator : MonoBehaviour
{
    public KeyCode triggerCode = KeyCode.E;
    public Transform Start;
    public Transform End;
    public GameObject BridgeUnit;
    public bool Active = true;

    void OnPlayerStay(Collider c)
    {
        if (Input.GetKeyDown(triggerCode))
        {
            var begin = Start.position;
            var end = End.position;
            var offset = end - begin;
            var distance = offset.magnitude;
            var count = Mathf.FloorToInt(distance);

            for (int i = 0; i <= count; ++i)
            {
                var point = begin + offset * i / count;
                Instantiate(BridgeUnit, point, Quaternion.identity);
            }
            Active = false;
        }
    }
}
