using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFloor : MonoBehaviour
{
    public Transform nextPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = nextPoint.position;

        if (collision.TryGetComponent(out EnemyMovement enemyMovement))
        {
            enemyMovement.pathIndex++;
        }
    }
}
