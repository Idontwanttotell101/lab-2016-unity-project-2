using UnityEngine;
using System.Collections;

public class guardalert : MonoBehaviour
{

    GameObject Player;
    public float playerDetectDistance = 6;
    public float fieldOfViewRange = 60;
    [SerializeField]
    float alertValue = 0;
    float maxAlertValue = 10;
    float alertDropDownRate = 1; //per second
    [SerializeField]
    Material alertMark;

    bool alert = false;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("CanSeePlayer");
        StartCoroutine("SoundDetection");
    }

    void Update()
    {
        var color = GetComponent<Renderer>().material.color;
        color.r = 255 * alertValue / maxAlertValue;
        GetComponent<Renderer>().material.color = color;
        Player.GetComponent<statement>().alertRate = alertValue / maxAlertValue *100;
        if (alert)
        {
            alert = false;
            StopAllCoroutines();
            StartCoroutine("StartTrace");
        }
        alertMark.SetFloat("_TransparentRate", alertValue/10);
    }

    IEnumerator CanSeePlayer()
    {
        while (true)
        {
            RaycastHit hit;
            Vector3 rayDirection = Player.transform.position - transform.position;
            float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
            if (Vector3.Angle(rayDirection, transform.forward) < fieldOfViewRange
                && Physics.Raycast(transform.position, rayDirection, out hit, playerDetectDistance)
                && hit.transform.tag == "Player")
            { alert = true; alertValue = 10; yield return null; }
            else { yield return null; }
        }
    }

    IEnumerator StartTrace()
    {
        GetComponent<NavMeshAgent>().speed = 6;
        GetComponent<NavMeshAgent>().acceleration = 100;
        GetComponent<guardMove>().enabled = false;
        while (true)
        {
            GetComponent<NavMeshAgent>().destination = Player.transform.position;
            yield return null;
        }
    }

    IEnumerator SoundDetection()
    {
        while (true)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            alertValue += (15 * Mathf.Exp(-0.5f * distance) - alertDropDownRate) * Time.deltaTime;
            if (alertValue < 0) alertValue = 0;
            if (alertValue > maxAlertValue)
            {
                alertValue = maxAlertValue;
                alert = true;
            }
            yield return null;
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }
}
