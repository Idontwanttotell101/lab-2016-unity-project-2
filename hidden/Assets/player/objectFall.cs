using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class objectFall : MonoBehaviour
{
    private int countdown = 5;
    public int ThresholdFrame = 5;
    [Tooltip("Object To Fall.\nIf this field is null on Start(), the root object is used instead.")]
    public GameObject target;

    void Start()
    {
        countdown = ThresholdFrame;
        if (target == null)
            target = transform.root.gameObject;
    }

    void Update()
    {
        --countdown;
        if (countdown < 0)
        {
            Fall();
            this.enabled = false;
        }
    }

    private void Fall()
    {
        target.AddComponent<FallOperator>();
    }

    void OnTriggerStay(Collider c)
    {
        countdown = ThresholdFrame;
    }
}
