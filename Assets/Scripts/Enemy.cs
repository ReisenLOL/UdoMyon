using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public UnitStats stats;
    public float closestTargetDistance;
    public float maximumTargetDistance;

    
    private void FixedUpdate()
    {
        if (stats.closestTarget)
        {
            float distanceToTarget = Vector3.Distance(stats.closestTarget.transform.position, transform.position);
            if (distanceToTarget < closestTargetDistance)
            {
                rb.linearVelocity = -(stats.closestTarget.transform.position - transform.position).normalized * stats.speed;
            }
            else if (distanceToTarget >= closestTargetDistance && distanceToTarget <= maximumTargetDistance)
            {
                rb.linearVelocity = Vector3.zero;
            }
            else
            {
                rb.linearVelocity = (stats.closestTarget.transform.position - transform.position).normalized * stats.speed;
            }
        }
    }
}
