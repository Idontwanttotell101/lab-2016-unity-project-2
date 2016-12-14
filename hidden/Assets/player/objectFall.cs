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
        var components = target.GetComponentsInChildren<Component>();
        foreach (var com in components.Where(x => !(x is Renderer || x is Transform || x is objectFall)))
        {
            
            if (com is Rigidbody) GameObject.DestroyImmediate(com);
            if (com is Behaviour) (com as Behaviour).enabled = false;
            else GameObject.Destroy(com);
            
            //GameObject.DestroyImmediate(com);
        }
        var rig = target.AddComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider c)
    {
        countdown = ThresholdFrame;
    }
}
