using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 15;
    
    private bool isDestroyed = false;
    public GameObject Child;
    public GameObject thisThing;
    public static bool isDead;
    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth);
            isDestroyed = true;
            Destroy(gameObject);
           


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            TakeDamage(bullet.GetComponent<Bullet>().bulletDamage);
        }
    }
}
