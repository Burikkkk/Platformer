using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemyHealth = other.gameObject.GetComponent<Health>();
            enemyHealth.Decrease(player.Damage);
        }
    }
}
