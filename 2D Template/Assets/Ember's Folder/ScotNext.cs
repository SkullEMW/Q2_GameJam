using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScotNext : MonoBehaviour
{
    public GameObject ScotCreditP1;
    public GameObject ScotCreditP2;


    public void whenButtonClicked()
    {
        if (ScotCreditP1.activeInHierarchy)
        {
            ScotCreditP1.SetActive(false);

        }
        else
        {
            ScotCreditP1.SetActive(true);
        }


        if (ScotCreditP2.activeInHierarchy)
        {
            ScotCreditP2.SetActive(false);

        }
        else
        {
            ScotCreditP2.SetActive(true);
        }
    }

    }
