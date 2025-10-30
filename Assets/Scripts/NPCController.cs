using System;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerController playerToFollow;
    public float maximumPlayerDistance;
    public float closestTargetDistance;
    public float maximumTargetDistance;
    public Transform target;

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (!target)
        {
            float distanceToPlayer = Vector3.Distance(playerToFollow.transform.position, transform.position);
            if (distanceToPlayer > maximumPlayerDistance)
            {
                playerController.rb.linearVelocity = (playerToFollow.transform.position - transform.position).normalized * playerController.stats.speed;
            }
            else
            {
                playerController.rb.linearVelocity = Vector3.zero;
            }
            return;
        }
        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        if (distanceToTarget < closestTargetDistance)
        {
            playerController.rb.linearVelocity = -(target.transform.position - transform.position).normalized * playerController.stats.speed;
        }
        else if (distanceToTarget >= closestTargetDistance && distanceToTarget <= maximumTargetDistance)
        {
            playerController.rb.linearVelocity = Vector3.zero;
        }
        else
        {
            playerController.rb.linearVelocity = (target.transform.position - transform.position).normalized * playerController.stats.speed;
        }
    }
}
