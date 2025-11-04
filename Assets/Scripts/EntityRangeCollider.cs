using System;
using UnityEngine;

public class EntityRangeCollider : MonoBehaviour
{
    public Entity entity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(entity.tag))
        {
            other.TryGetComponent(out Entity entityFound);
            entity.unitsInRange.Add(entityFound);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(entity.tag) && other.TryGetComponent(out Entity entityFound) && entity.unitsInRange.Contains(entityFound))
        {
            entity.unitsInRange.Remove(entityFound);
        }
    }
}
