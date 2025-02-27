using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float speedBoost = 2f;
    private float rayLength = 1.0f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (CheckGrounded())
            State = States.Idle;
        if (Input.GetButton("Horizontal"))
            Run();
        if (CheckGrounded() && Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (CheckGrounded()) State = States.Slide;
            speed *= speedBoost;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || Input.GetKeyUp(KeyCode.LeftShift))
            speed /= speedBoost;
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attack();
    }




    private void Run()
    {
        if (CheckGrounded()) State = States.Run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }



    private bool CheckGrounded()
    {
        return Physics2D.Raycast(this.transform.position, Vector2.down, rayLength, groundLayer.value);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        if (!CheckGrounded()) State = States.Jump;

    }

    private void Attack()
    {
        State = States.Attack;
    }

    public enum States
    {

        Idle, 
        Run,
        Slide,
        Attack,
        HurtNoEffect,
        DeathNoEffect,
        Jump
    }

    private States State
    {
        get { return (States)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
  
    }
}
