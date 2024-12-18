using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int currency;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 100;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;

        }
        else
        {

            Debug.Log("You do not have enough to purchase this item");
            return false;

        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < path.Length - 1; i++)
        {
            Gizmos.DrawLine(path[i].position, path[i + 1].position);
        }
    }
}

