using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class teleport : MonoBehaviour
{
    public teleport tele;

    List<GameObject> current = new List<GameObject>();

    // Use this for initialization
    void OnTriggerEnter(Collider c)
    {
        if (!(c.gameObject.tag == "Player")) return;
        if (current.Exists(x => x == c.gameObject)) return;
        tele.current.Add(c.gameObject);
        float deltaY = c.gameObject.transform.position.y - transform.position.y;
        c.gameObject.transform.position = tele.transform.position + Vector3.up * deltaY;
        //c.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


    // Use this for initialization
    void OnTriggerExit(Collider c)
    {
        current.Remove(c.gameObject);
    }
}
