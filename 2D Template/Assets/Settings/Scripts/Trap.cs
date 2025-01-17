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

<<<<<<< HEAD
    
=======

   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>() != null)
        {
            collision.GetComponent<EnemyMovement>().trigger++;
        }

    }
>>>>>>> 6850f33d4dc94a65c97cf1effb39efc63d196614
}
