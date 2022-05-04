using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public int enemyHealth;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("BulletPlayer"))
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
