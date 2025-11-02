using System;
using System.Collections.Generic;
using Core.Extensions;
using UnityEngine;

public class YoumuSlash : PlayerAbility
{
    public List<Entity> enemiesInRange = new();
    public Animator animator;
    public string animationTrigger;
    public string animationStateName;
    public bool canRotate = true;
    public float knockbackForce;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(tag) && other.TryGetComponent(out Entity isEntity))
        {
            enemiesInRange.Add(isEntity);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (!other.CompareTag(tag) && other.TryGetComponent(out Entity isEntity) && enemiesInRange.Contains(isEntity))
        {
            enemiesInRange.Remove(isEntity);
        }
    }

    protected override void Update()
    {
        base.Update();
        if (thisPlayer.enabled && canRotate)
        {
            transform.Lookat2D(PlayerSwitcher.instance.mouseWorldPos);
        }
    }

    public void SetRotate()
    {
        canRotate = !canRotate;
    }
    protected override void AbilityEffects()
    {
        
        foreach (Entity entityFound in enemiesInRange)
        {
            entityFound.TakeDamage(thisPlayer.stats.damage);
            Vector3 knockbackDirection = (entityFound.transform.position - thisPlayer.transform.position).normalized;
            entityFound.rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
        animator.SetTrigger(animationTrigger);
    }
}
