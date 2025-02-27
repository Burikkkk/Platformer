using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    private GameObject player;
    private Health playerHealth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    public void Attack()
    {
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance <= attackRange)
            playerHealth.Decrease(damage);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == player)
        {
            // start attack anim
            Attack();
        }
    }
}
