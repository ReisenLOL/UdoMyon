using UnityEngine;

public class EnemyShoot : EnemyAttack
{
    public Projectile projectile;
    public override void Attack()
    {
        Projectile newProjectile = Instantiate(projectile, transform.position, projectile.transform.rotation);
        newProjectile.damage = thisEnemy.stats.damage;
        newProjectile.tag = "Enemy";
        newProjectile.originEntity = thisEnemy.stats;
        newProjectile.RotateToTarget(thisEnemy.stats.closestTarget.transform.position);
    }
}
