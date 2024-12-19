using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    public int pathIndex = 0;

    private void Update()
    {
        if (Vector2.Distance(LevelManager.main.path[pathIndex].position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (LevelManager.main.path[pathIndex].position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
}
