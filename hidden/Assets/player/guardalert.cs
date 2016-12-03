using UnityEngine;
using System.Collections;

public class guardalert : MonoBehaviour
{
    public GameObject Player;
    public float minPlayerDetectDistance;
    public float fieldOfViewRange;

    void Update()
    {
        canSeePlayer();

    }

    bool canSeePlayer()
    {
        RaycastHit hit;
        Vector3 rayDirection = Player.transform.position - transform.position;
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (Vector3.Angle(rayDirection, transform.forward) < fieldOfViewRange)
        { // Detect if player is within the field of view
            Debug.Log("in the field");
            if (Physics.Raycast(transform.position, rayDirection, out hit, minPlayerDetectDistance))
            {

                if (hit.transform.tag == "Player")
                {
                    Debug.Log("Can see player");
                    return true;
                }
                else
                {
                    Debug.Log("Can not see player");
                    return false;
                }
            }
            return false;
        }
        else { return false; }
    }
}
