using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttackEvents : MonoBehaviour
{
    [SerializeField] private Player player;

    public void UnsetAttacks()
    {
        player.SetAttacks(false);
    }
    
    public void RestartOnDeath()
    {
        ChangeScene.Restart();
    }
}
