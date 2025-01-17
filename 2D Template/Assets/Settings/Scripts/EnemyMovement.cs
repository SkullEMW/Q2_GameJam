using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    public int trigger;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    [HideInInspector] public float currentTime;

    public int pathIndex = 0;
    public Sprite Pointywalkspritesheet;
    public bool grabbed;
    public GameObject Child;
    public GameObject thisThing;
    public bool isDead;

    
    private void Update()
    {
       
        if (Vector2.Distance(LevelManager.main.path[pathIndex].position, transform.position) <= 0.1f)
        {
            pathIndex++;
            if (pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                return;
            }
        }
        if ((rb.velocity).x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if ((rb.velocity).x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }


    private void OnDestroy()
    {
       //transform.GetChild(0)?.gameObject.SetActive(true);
       transform.GetChild(0)?.SetParent(null);
    }


    private void FixedUpdate()
    {
        Vector2 direction = ((Vector2)LevelManager.main.path[pathIndex].position - (Vector2)transform.position).normalized;

        Vector2 dir = (direction * moveSpeed);
        //print(dir);

        if (currentTime > 0)
        {
            currentTime -= Time.fixedDeltaTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(Mathf.Clamp(dir.x, -moveSpeed, moveSpeed), Mathf.Clamp(dir.y, -moveSpeed, moveSpeed));
        }

    }
}
