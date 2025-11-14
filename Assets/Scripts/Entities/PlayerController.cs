using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Identification")] 
    public Sprite portrait;
    [Header("Unit")]
    public PlayerStats stats;
    public NPCController npcSelf;
    [Header("Movement")]
    public Vector3 moveDirection;
    public Rigidbody2D rb;
    [Header("Abilities")] 
    public PlayerAbility mainAttack;
    public PlayerAbility mainAttackInstance;
    [Header("Cache")]
    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        mainAttackInstance = Instantiate(mainAttack, transform);
        mainAttackInstance.thisPlayer = this;
    }

    private void Update()
    {
        HandleMovement();
        if (Input.GetMouseButton(0))
        {
            mainAttackInstance.ActivateAbility();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * stats.speed;
    }
    private void HandleMovement()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }
}
