using UnityEngine;

public class PlayerStats : UnitStats
{
    public Transform healthBar;

    public override void Heal(float healing)
    {
        base.Heal(healing);
        UpdateHealthBar();
    }

    public override void TakeDamage(float damageTaken)
    {
        base.TakeDamage(damage);
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3(health/maxHealth, 1f,1f);
    }
}
