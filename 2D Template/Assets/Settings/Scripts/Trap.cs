using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    [Header("Attributes")]
    Animation Chandelierspritesheet;
    public int TrapDamage = 3;
    private Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(TrapDamage);

        if (other.GetComponent<EnemyMovement>() != null)
        {
            anim = GetComponent<Animator>();
            anim.SetTrigger("Triggered");
            Destroy(gameObject,1);
        }
    }



   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>() != null)
        {
            collision.GetComponent<EnemyMovement>().trigger++;
        }

    }

}
