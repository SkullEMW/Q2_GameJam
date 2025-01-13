using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kidnap : MonoBehaviour
{
    public GameObject child;
    public GameObject TankEnemy;

    public Transform parent;

    public int childCount;
    private int childrenSafe;
    private int Count; 

    public string kidnappy;

    Vector3 ChildPos;
   

    private void Start()
    {
        ChildPos = transform.position;
        Count = 0;
        childCount = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(kidnappy))
        {
            transform.SetParent(collision.transform);
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

            collision.GetComponent<EnemyMovement>().currentTime = 2;

            childrenSafe = childCount - 1;

            if TanEnemy = T
            {
                
            }
            

        }
       
       
    }
    private void Update()
    {
        if (childCount == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    
}
