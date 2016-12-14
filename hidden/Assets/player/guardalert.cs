﻿using UnityEngine;
using System.Collections;

public class guardalert : MonoBehaviour
{

    GameObject Player;
    public float minPlayerDetectDistance;
    public float fieldOfViewRange;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

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
        { 
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit, minPlayerDetectDistance))
            {

                if (hit.transform.tag == "Player")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        else { return false; }
    }
}
