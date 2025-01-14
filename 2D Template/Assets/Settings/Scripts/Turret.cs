using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;
using System.Runtime.CompilerServices;
using System.Linq;
using Unity.VisualScripting;

public class Turret : MonoBehaviour
{
    Rigidbody2d rb;

    float inputHorizontal;
    float inputVertical;
    Animation BluePlacement;
    Animation PurplePlacement;
    bool facingRight = true;
   
    

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
    private Animator LaseTurret;
    public Sprite BluePlacementSpriteSheet_0;
    public Sprite PurplePlacementSpriteSheet_0;
    private static object onDrawGizmos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        timeUntilFire = 1f / bps;
        if (anim)
        {
            anim.SetTrigger("Spawn");
        }

    }

    private void Update()
    {
        FindTargets();  
        Transform Target = GetClosestTarget();
        


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
        if ((target.position - transform.position).x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);

        if (GetClosestTarget())
            Gizmos.DrawLine(transform.position, GetClosestTarget().position);

    }
    private void FixedUpdate()
    {
        





    }


    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    public class ExampleClass : MonoBehaviour
    {
        public Transform other;

        void Update()
        {
            if (other)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 toOther = Vector3.Normalize(other.position - transform.position);

                if (Vector3.Dot(forward, toOther) < 0)
                {
                    print("The other transform is behind me!");
                }
            }
        }
    }


}
