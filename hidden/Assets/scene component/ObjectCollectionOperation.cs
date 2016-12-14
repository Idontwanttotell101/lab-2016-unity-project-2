using System.Collections.Generic;
using UnityEngine;

public class ObjectCollectionOperation : MonoBehaviour
{
    public List<GameObject> objects;

    public void DestroyAll()
    {
        var objs = objects;
        objects = new List<GameObject>();

        foreach (var obj in objs)
        {
            GameObject.Destroy(obj);
        }
    }
}
