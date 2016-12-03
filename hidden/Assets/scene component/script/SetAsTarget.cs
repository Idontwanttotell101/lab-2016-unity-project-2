using UnityEngine;
using System.Collections;

public class SetAsTarget : MonoBehaviour
{

    // Use this for initialization
    void OnMouseDown()
    {
        FindObjectOfType<NavMeshAgent>().destination = this.transform.position;
    }
}
