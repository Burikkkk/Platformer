using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform targetLeft;
    [SerializeField] private Transform targetRight;
    [SerializeField] private int direction = 1;  // 1 право, -1 лево
    private bool canMove = true;
    
    private void Update()
    {
        if(targetLeft == null || targetRight == null)
            return;
        
        if(!canMove)
            return;
        
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

    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    public int Direction
    {
        get { return direction; }
    }

    public void ChangeDirection()
    {
        direction *= -1;
        
        var newScale = transform.localScale;    // поворот модельки
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
