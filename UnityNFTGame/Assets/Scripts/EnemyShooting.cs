using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int waitTime;
    float timer = 0;

    public float bulletForce = 20f;

    void Update()
    {
        Shoot(waitTime);
    }

    void Shoot(int waitTime)
    {
        if(timer > waitTime)
        {
            timer = 0;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
