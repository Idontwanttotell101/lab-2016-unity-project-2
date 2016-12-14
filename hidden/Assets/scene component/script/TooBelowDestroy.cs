using UnityEngine;
using System.Collections;

public class TooBelowDestroy : MonoBehaviour
{
    public float limitY = -100;
    public float CleanUpDuration = 2000;

    void Start()
    {
        InvokeRepeating("CleanUp", 0, CleanUpDuration);
    }

    // Update is called once per frame
    void CleanUp()
    {
        var objects = GameObject.FindObjectsOfType<Transform>();
        foreach (var o in objects)
        {
            if (o.position.y < limitY)
                Destroy(o.gameObject);
        }
    }
}
