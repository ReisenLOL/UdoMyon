using System;
using UnityEngine;

public class SwitchObstacle : MonoBehaviour
{
    public GameObject doorToOpen;
    public void ObstacleEffects()
    {
        doorToOpen.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Friendly") && other.gameObject.TryGetComponent(out Projectile isProjectile))
        {
            Destroy(other.gameObject);
            ObstacleEffects();
        }
    }
}
