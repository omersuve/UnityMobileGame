using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public int enemyHealth;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity /= 8;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
                ScoreScript.scoreValue += 1;
            }
            else
            {
                enemyHealth -= 1;
            }
        }
    }
}
