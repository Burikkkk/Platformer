using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEvents : MonoBehaviour
{
    [SerializeField] private Player player;

    public void UnsetAttacks()
    {
        player.SetAttacks(false);
    }
}
