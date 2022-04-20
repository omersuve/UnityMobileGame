using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI3 : MonoBehaviour
{
    public Transform target;
    public GameObject enemyPrefab;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    GameObject enemy;

    void Start()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        enemy = GameObject.FindGameObjectWithTag("Enemy3");

        Debug.Log(enemy);

        seeker = GetComponent<Seeker>();
        rb = enemy.GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone() && !IsDestroyed(enemy))
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsDestroyed(enemy))
        {
            UpdateUntilDestroyed();
        }
    }

    void UpdateUntilDestroyed()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        Vector2 directionRotation = (Vector2)target.position - rb.position;
        float angle = Mathf.Atan2(directionRotation.y, directionRotation.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    public bool IsDestroyed(GameObject gameObject)
    {
        return gameObject == null && !ReferenceEquals(gameObject, null);
    }
}
