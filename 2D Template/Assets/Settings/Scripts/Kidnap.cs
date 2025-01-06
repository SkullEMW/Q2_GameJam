using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kidnap : MonoBehaviour
{
    public GameObject child;

    public Transform parent;

    public string kidnappy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //gameObject.transform child = parent;

        if (collision.gameObject.CompareTag(kidnappy))
        {
            transform.SetParent(collision.transform);
        }
    }
}
