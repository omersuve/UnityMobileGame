using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BulletEnemy1")
            TakeDamage(15);
        if (col.gameObject.tag == "BulletEnemy2")
            TakeDamage(75);
    }
}
