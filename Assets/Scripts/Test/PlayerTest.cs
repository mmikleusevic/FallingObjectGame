using System;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    private int health;
    [SerializeField] private int healthMax;

    private void Start()
    {
        health = healthMax / 2;
    }

    public void Damage()
    {
        health -= 2;
        
        Debug.Log(health);
    }

    public void Heal()
    {
        if (health >= healthMax) return;
        
        health++;
        Debug.Log(health);
    }
}
