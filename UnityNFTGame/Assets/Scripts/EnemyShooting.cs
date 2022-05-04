using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float avgWaitTime;
    public float bulletForce = 20f;
    
    float timer = 0;
    bool shooted = false;
    double wait = 3;
    private Transform target;
    string[] layers = new string[] {"Mountain", "Forest"};

    System.Random rand = new System.Random();

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (shooted)
        {
            wait = calculateWaitingTime(avgWaitTime);
            shooted = false;
        }

        if (timer > wait)
        {
            int environment = LayerMask.GetMask(layers);
            if (!Physics2D.Linecast(transform.position, target.transform.position, environment))
            {
                timer = 0;
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                shooted = true;
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    double calculateWaitingTime(double avgWaitTime)
    {
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        double randNormal = avgWaitTime + 1.5 * randStdNormal;
        print("randNormal: " + randNormal.ToString());
        return randNormal;
    }
}
