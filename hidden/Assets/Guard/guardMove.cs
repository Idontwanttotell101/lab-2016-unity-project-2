using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class guardMove : MonoBehaviour
{

    public Transform[] CheckPoints;
    private NavMeshAgent agent;
    IEnumerator<Transform> nextTarget;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nextTarget = CheckPoints.InfinityRepeat().GetEnumerator();
        nextTarget.MoveNext();
        agent.destination = nextTarget.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        //try
        
        {
            if (Vector3.Distance(transform.position, nextTarget.Current.position) > 1) return;
        }
        //catch (MissingReferenceException)
        {
            //move next
        }
        do nextTarget.MoveNext(); while (nextTarget.Current == null);
        agent.destination = nextTarget.Current.position;
    }
}
