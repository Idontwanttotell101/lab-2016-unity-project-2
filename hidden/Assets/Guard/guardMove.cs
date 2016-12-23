using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class guardMove : MonoBehaviour
{

    public Transform[] CheckPoints;
    private UnityEngine.AI.NavMeshAgent agent;
    public IEnumerator<Transform> nextTarget;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nextTarget = CheckPoints.InfinityRepeat().GetEnumerator();
        nextTarget.MoveNext();
        agent.destination = nextTarget.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            agent.destination = nextTarget.Current.position;
            if (Vector3.Distance(transform.position, nextTarget.Current.position) > 1) return;
        }
        catch (MissingReferenceException)
        {
            //move next
            if (CheckPoints.Count(x => x != null) <= 1)
            {
                Debug.Log("no more avalible checkpoints to move to", this);
                this.enabled = false;
                agent.enabled = false;
                return;
            }
        }
        do nextTarget.MoveNext(); while (nextTarget.Current == null);
        agent.destination = nextTarget.Current.position;
    }
}
