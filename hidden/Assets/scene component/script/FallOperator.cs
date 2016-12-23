using UnityEngine;
using System.Linq;

public class FallOperator : MonoBehaviour
{
    void Start()
    {
        var components = gameObject.GetComponentsInChildren<Component>();
        foreach (var com in components.Where(x => !(x is Renderer || x is Transform || x is FallOperator || x is MeshFilter)))
        {
            if (com is Rigidbody) GameObject.DestroyImmediate(com);
            else GameObject.Destroy(com);
        }
        gameObject.AddComponent<Rigidbody>();
    }
}
