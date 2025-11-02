using System;
using UnityEngine;

public class EnemyRangeCollider : MonoBehaviour
{
    public Enemy thisEnemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(thisEnemy.tag))
        {
            other.TryGetComponent(out Entity entityFound);
            thisEnemy.unitsInRange.Add(entityFound);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(thisEnemy.tag) && other.TryGetComponent(out Entity entityFound) && thisEnemy.unitsInRange.Contains(entityFound))
        {
            thisEnemy.unitsInRange.Remove(entityFound);
        }
    }
}
