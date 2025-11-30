using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float detectionRange = 10f;

    private Rigidbody2D rb;
    public Transform enemyGFX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target == null)
            return;

        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= detectionRange)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            if (enemyGFX != null)
            {
                if (force.x >= 0.01f)
                {
                    enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
                }
                else if (force.x <= -0.01f)
                {
                    enemyGFX.localScale = new Vector3(1f, 1f, 1f);
                }
            }
        }
    }
}
