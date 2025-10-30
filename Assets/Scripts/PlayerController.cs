using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Unit")]
    public UnitStats stats;
    public NPCController npcSelf;
    [Header("Movement")]
    public Vector3 moveDirection;
    public Rigidbody2D rb;
    [Header("Abilities")] 
    public PlayerAbility mainAttack;
    public PlayerAbility mainAttackInstance;
    [Header("Cache")]
    public Vector3 mouseWorldPos;
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
        if (Input.GetMouseButtonDown(0))
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
        mouseWorldPos =  cam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,cam.nearClipPlane));
    }
}
