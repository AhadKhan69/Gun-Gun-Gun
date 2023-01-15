using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float moveSpeed;
    public float moveMaxSpeed;
    public float jumpPower;
    public Vector2 direction;
    public bool canJump;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        canJump = true;
    }
    private void LateUpdate()
    {
        if (rb.velocity.magnitude>=moveMaxSpeed)
        {
            return;
        }
        Movevement();
    }

    private void Movevement()
    {
        if (direction==Vector2.zero )
        {
            return;
        }
        rb.AddForce(direction * moveSpeed, ForceMode2D.Impulse);

    }
    public void Jump()
    {
        if (!canJump)
        {
            return;
        }
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

    }
    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
    internal void SetMoveDirection(Vector2 direction)=>this.direction= direction;
    
}
