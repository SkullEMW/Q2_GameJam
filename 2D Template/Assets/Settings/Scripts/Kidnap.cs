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
    public Vector2 respawnLocation;
    public float respawnTime = 5;
    public Transform parent;

    public int childCount;
    private int childrenSafe;
    private int Count; 

    public string kidnappy;

    Vector3 ChildPos;



    
    private void Start()
    {
        respawnLocation = transform.position;
        ChildPos = transform.position;
        Count = 0;
        childCount = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(kidnappy) && collision.gameObject.GetComponent<EnemyMovement>().grabbed == false)
        {
            GetComponent<Animator>().SetBool("IsHiding", false);
            collision.GetComponent<Animator>().SetBool("HasChild", true);
            transform.SetParent(collision.transform);
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            collision.GetComponent<EnemyMovement>().currentTime = 2;
            childrenSafe = childCount - 1;
            collision.gameObject.GetComponent<EnemyMovement>().grabbed = true;
            //collision.gameObject.GetComponent<EnemyMovement>().Child = this.transform;
            collision.gameObject.GetComponent<EnemyMovement>().Child = this.gameObject;
            gameObject.SetActive(false);
        }
       
       
    }
    
    private void Update()
    {
        if (transform.parent == null)// && EnemyMovement.isDead == true)
        {
            //StartCoroutine(RespawnThisThing());
            
        }
        if (childCount == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    //public IEnumerator RespawnThisThing()
    //{
    //    child.transform.SetParent(null);
    //    Debug.Log("RIGHT HERE");
    //}
}
