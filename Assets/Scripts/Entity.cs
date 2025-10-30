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
    //public DamageNumberSO onHitDamageNumber;
    public virtual void TakeDamage(float damage)
    {
        if (!invulnerable)
        {
            health -= damage - defense; 
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
