using System;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerController playerToFollow;
    public float maximumPlayerDistance;
    public float closestTargetDistance;
    public float maximumTargetDistance;

    private void Update()
    {
        if (playerController.stats.closestTarget)
        {
            playerController.mainAttackInstance.ActivateAbility();
        }
    }

    private void FixedUpdate()
    {
        if (!playerController.stats.closestTarget)
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
        float distanceToTarget = Vector3.Distance(playerController.stats.closestTarget.transform.position, transform.position);
        if (distanceToTarget < closestTargetDistance)
        {
            playerController.rb.linearVelocity = -(playerController.stats.closestTarget.transform.position - transform.position).normalized * playerController.stats.speed;
        }
        else if (distanceToTarget >= closestTargetDistance && distanceToTarget <= maximumTargetDistance)
        {
            playerController.rb.linearVelocity = Vector3.zero;
        }
        else
        {
            playerController.rb.linearVelocity = (playerController.stats.closestTarget.transform.position - transform.position).normalized * playerController.stats.speed;
        }
    }
}
