using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using System;
using System.Runtime.CompilerServices;
using System.Linq;
using Unity.VisualScripting;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private LayerMask WallMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float bps = 1f; // Bullets Per Second
    
    private List<Transform> targets = new();
    private float timeUntilFire;
    private Animator anim;
    public Sprite BluePlacementSpriteSheet_0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        timeUntilFire = 1f / bps;
    }

    private void Update()
    {
        FindTargets();  
        Transform Target = GetClosestTarget();
        if (Target==true)
        {
            
        }


        timeUntilFire += Time.deltaTime;

        if (Target)
        {
            RotateTowardsTarget(Target);
            

            if (timeUntilFire >= 1f / bps)
            {
                Shoot(Target);
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot(Transform target)
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);

        if (anim)
        {
            anim.SetTrigger("Attack");
        }
    }
    //private void FindTarget() {

    private Transform GetClosestTarget()
    {
        return targets.OrderBy(item => Vector2.Distance(transform.position, item.position)).FirstOrDefault();
    }
      
    private void FindTargets()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, Vector2.zero, 999f, enemyMask);

        targets.Clear();
        foreach (RaycastHit2D hit in hits)
        {
            if (!Physics2D.Linecast(transform.position,hit.point, WallMask))
            {
                targets.Add(hit.transform);
            }
        }
    }

    private void RotateTowardsTarget(Transform target)
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;


        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
        Gizmos.DrawLine(transform.position, GetClosestTarget().position);

    }

   
    
}
