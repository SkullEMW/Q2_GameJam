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
        Vector2 direction = ((Vector2)LevelManager.main.path[pathIndex].position - (Vector2)transform.position).normalized;

        Vector2 dir = (direction * moveSpeed);
        print(dir);

        rb.velocity = new Vector2(Mathf.Clamp(dir.x, -moveSpeed, moveSpeed), Mathf.Clamp(dir.y, -moveSpeed, moveSpeed));
        //print(rb.velocity);
    }
}
