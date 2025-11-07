using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Enemy thisEnemy;
    public float currentAttackTime;
    public void TryAttack()
    {
        currentAttackTime += Time.deltaTime;
        if (currentAttackTime > thisEnemy.stats.attackSpeed && thisEnemy.stats.closestTarget)
        {
            currentAttackTime = 0f;
            Attack();
        }
    }

    public virtual void Attack()
    {
        //insert attack code here
    }
}
