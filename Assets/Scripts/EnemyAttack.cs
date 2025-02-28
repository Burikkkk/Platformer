using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    private bool attacks;
    
    private GameObject player;
    private Health playerHealth;

    private EnemyMove enemyMove;
    private Animator animator;
    private bool stopAttack;
    private bool dead;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();

        enemyMove = GetComponent<EnemyMove>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(dead)
            return;
        
        if(!attacks)
            return;
        
        // если враг атакует, игрок слева от врага, а враг смотрит вправо, то поворачивается
        if (player.transform.position.x < transform.position.x && enemyMove.Direction == 1)
        {
            enemyMove.ChangeDirection();
        }
        // то же самое, но игрок справа, а враг смотрит влево
        if (player.transform.position.x > transform.position.x && enemyMove.Direction == -1)
        {
            enemyMove.ChangeDirection();
        }
    }

    public void Attack()
    {
        float distance = (transform.position - player.transform.position).magnitude;
        if (distance <= attackRange)
        {
            playerHealth.Decrease(damage);
        }
        else
        {
            stopAttack = true;
        }
    }

    // надо OnAttackAnimationEnd 
    public void OnAnimationEnd()
    {
        if (stopAttack)
        {
            animator.SetBool("attacks", false);
            stopAttack = false;
            attacks = false;
            enemyMove.CanMove = true;
        }
    }
    
    public void Die()
    {
        animator.SetBool("dead", true);
        GetComponent<Collider2D>().enabled = false;
        dead = true;
    }

    public void OnDeathAnimationEnd()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == player)
        {
            animator.SetBool("attacks", true);
            attacks = true;
            enemyMove.CanMove = false;
        }
    }
}
