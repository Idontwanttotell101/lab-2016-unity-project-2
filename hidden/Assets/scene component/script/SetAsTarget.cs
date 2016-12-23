using UnityEngine;
using System.Collections;

public class SetAsTarget : MonoBehaviour
{

    // Use this for initialization
    void OnMouseDown()
    {
        FindObjectOfType<UnityEngine.AI.NavMeshAgent>().destination = this.transform.position;
    }
}
