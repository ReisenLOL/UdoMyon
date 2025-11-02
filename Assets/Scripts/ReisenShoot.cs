using UnityEngine;

public class ReisenShoot : PlayerAbility
{
    public Projectile projectile;
    protected override void AbilityEffects()
    {
        Projectile newProjectile = Instantiate(projectile, transform.position, projectile.transform.rotation);
        newProjectile.damage = thisPlayer.stats.damage;
        newProjectile.tag = "Friendly";
        newProjectile.originEntity = thisPlayer.stats;
        newProjectile.RotateToTarget(PlayerSwitcher.instance.mouseWorldPos);
    }
}