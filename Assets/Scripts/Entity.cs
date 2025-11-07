using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour //entity and unit are for health and stats only. the targetting and controlling will use a different script.
{
    [Header("Identification")] 
    public string entityName;
    [Header("HEALTH")] 
    public float health;
    public float maxHealth;
    public float defense;
    public bool invulnerable;
    public Rigidbody2D rb;
    
    [Header("Range")]
    public List<Entity> unitsInRange = new();
    public Entity closestTarget = null;
    //public DamageNumberSO onHitDamageNumber;

    private void Update()
    {
        if (unitsInRange.Count > 0)
        {
            closestTarget = FindClosestTarget(); //this code sucks
        }
        else
        {
            closestTarget = null;
        }
    }

    public Entity FindClosestTarget()
    {
        Entity foundEntity = null;
        foreach (Entity entity in unitsInRange.ToArray())
        {
            if (!entity)
            {
                unitsInRange.Remove(entity);
                continue;
            }
            if (!foundEntity || Vector3.Distance(entity.transform.position, transform.position) <
                Vector3.Distance(foundEntity.transform.position, transform.position))
            {
                foundEntity = entity;
            }
        }
        return foundEntity;
    }
    public virtual void TakeDamage(float damageTaken)
    {
        if (!invulnerable)
        {
            health -= damageTaken - defense; 
            //onHitDamageNumber.Spawn(transform.position, damage);
            if (health <= 0)
            {
                OnKillEffects();
            }
        }
    }
    public virtual void Heal(float healing)
    {
        health += healing;
        health = Mathf.Clamp(health, 0f, maxHealth);
    }
    protected virtual void OnKillEffects()
    {
        Destroy(gameObject);
    }
}
