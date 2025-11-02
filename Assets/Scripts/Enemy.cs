using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Entity> unitsInRange = new();
    public Entity closestTarget = null;
    public Rigidbody2D rb;
    public UnitStats stats;
    private Entity FindClosestTarget()
    {
        Entity foundEntity = null;
        foreach (Entity entity in unitsInRange.ToArray())
        {
            if (!foundEntity || Vector3.Distance(entity.transform.position, transform.position) <
                Vector3.Distance(foundEntity.transform.position, transform.position))
            {
                foundEntity = entity;
            }
        }
        return foundEntity;
    }

    private void Update()
    {
        closestTarget = FindClosestTarget();
    }

    private void FixedUpdate()
    {
        if (closestTarget)
        {
            rb.linearVelocity = (closestTarget.transform.position - transform.position).normalized * stats.speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
