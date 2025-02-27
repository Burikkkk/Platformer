using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    [SerializeField] private int hp = 30;
    [SerializeField] private float jumpForce = 15f;
    private float rayLength = 2.0f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (CheckGrounded() && Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }


    private void Run()
    {
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

    }
}
