using UnityEngine;

public class UnitStats : Entity
{
    [Header("Stats")]
    public float speed;
    public float damage;
    public float attackSpeed;
    [Header("Flags")]
    public bool canAttack = true;
    public bool canMove = true;
    [Header("CACHE")]
    public Rigidbody2D rb;
    public AudioSource audioSource;
}
