using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float hp;
    private float maxHp;

    private void Start()
    {
        maxHp = hp;
    }

    public void Increase(float value)
    {
        hp += value;
    }

    public float Percent()
    {
        return hp / maxHp;
    }

    public void Decrease(float value)
    {
        hp -= value;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var player = GetComponent<Player>();
        var enemy = GetComponent<EnemyAttack>();
        if (player != null)
        {
            player.Die();
            return;
        }

        if (enemy != null)
        {
            enemy.Die();
            return;
        }
        
    }
}
