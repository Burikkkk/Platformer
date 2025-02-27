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

    public void Decrease(float value)
    {
        hp -= value;
    }
}
