using UnityEngine;
using System.Collections;

public class guardalert : MonoBehaviour
{
    Player Player;
    status GM;
    public float playerDetectDistance = 6;
    public float fieldOfViewRange = 60;
    public float _alertValue = 0;
    private float AlertValue
    {
        get
        {
            return _alertValue;
        }
        set
        {
            _alertValue = Mathf.Clamp(value, 0, maxAlertValue);
        }
    }
    float maxAlertValue = 10;
    float alertDropDownRate = 1; //per second
    [SerializeField]
    Material alertMark;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        GM = GameObject.FindObjectOfType<status>();
        Player = GameObject.FindObjectOfType<Player>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        StartCoroutine(CanSeePlayer());
        StartCoroutine(SoundDetection());
    }

    void Update()
    {
        GM.alertRate = AlertValue / maxAlertValue * 100;
        alertMark.SetFloat("_TransparentRate", AlertValue / 10);
    }

    IEnumerator CanSeePlayer()
    {
        yield return null;
        while (true)
        {
            Debug.Log("See");
            RaycastHit hit;
            Vector3 rayDirection = Player.transform.position - transform.position;
            //float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
            if (Vector3.Angle(rayDirection, transform.forward) < fieldOfViewRange
                && Physics.Raycast(transform.position, rayDirection, out hit, playerDetectDistance)
                && hit.transform.tag == "Player"
                && !Player.Hidden)
            { StartTrace(); yield return null; }
            else { yield return null; }
        }
    }

    void StartTrace()
    {
        StopAllCoroutines();
        StartCoroutine(TraceRoutine());
    }

    void StopTrace()
    {
        StopAllCoroutines();
        StartCoroutine(CanSeePlayer());
        StartCoroutine(SoundDetection());
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 3.5f;
        GetComponent<UnityEngine.AI.NavMeshAgent>().acceleration = 8;
        GetComponent<guardMove>().enabled = true;
    }

    IEnumerator TraceRoutine()
    {
        yield return null;
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 6;
        GetComponent<UnityEngine.AI.NavMeshAgent>().acceleration = 100;
        GetComponent<guardMove>().enabled = false;
        while (true)
        {
            Debug.Log("Trace");
            if (Player.Hidden)
            {
                AlertValue -= alertDropDownRate * Time.deltaTime;
                if (AlertValue == 0)
                    StopTrace();
            }
            else
            {
                AlertValue = Mathf.Infinity;
                agent.destination = Player.transform.position;
            }
            yield return null;
        }
    }

    IEnumerator SoundDetection()
    {
        yield return null;
        while (true)
        {
            Debug.Log("Detection");
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            if (Player.Hidden) distance = Mathf.Infinity;
            AlertValue += (15 * Mathf.Exp(-0.5f * distance) - alertDropDownRate) * Time.deltaTime;

            if (AlertValue == maxAlertValue)
                StartTrace();
            yield return null;
        }
    }
}
