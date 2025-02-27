using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform targetLeft;
    [SerializeField] private Transform targetRight;
    private int direction = 1;  // 1 право, -1 лево
    
    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * direction); // движение в нужную сторону
        
        if (direction == 1 && transform.position.x >= targetRight.position.x)   // дошел до правого края
        {
            ChangeDirection();
        }

        if (direction == -1 && transform.position.x <= targetLeft.position.x)  // дошел до левого
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        direction *= -1;
        
        var newScale = transform.localScale;    // поворот модельки
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
