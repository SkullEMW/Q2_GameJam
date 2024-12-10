using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    [Header("Attributes")]
    public int TrapDamage = 3;


    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(TrapDamage);
       
        if (other.GetComponent<EnemyMovement>() != null)
        {
            Destroy(gameObject);
        }
    }
}
