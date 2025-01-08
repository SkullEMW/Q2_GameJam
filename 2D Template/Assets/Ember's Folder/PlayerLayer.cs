using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayer : MonoBehaviour
{
    public const string LAYER_NAME = "sprite";
    public int sortingOrder = 0;
    private SpriteRenderer sprite;
    public GameObject underwall;
    string objectName = "Underwall";


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        underwall = GameObject.Find(objectName);

        if (sprite)
        {
            sprite.sortingOrder = sortingOrder;
            sprite.sortingLayerName = LAYER_NAME;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(objectName))
        {
            sprite.sortingOrder = 100;

        }


    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag(objectName))
        {
            sprite.sortingOrder = 100;
            Console.Write("Under");
        }
    }

 
}

//This is so the enemy sprite goes in front of the walls when passing them 