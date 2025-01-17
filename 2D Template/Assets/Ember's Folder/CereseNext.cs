using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CereseNext : MonoBehaviour
{
    public GameObject CereseCreditP1;
    public GameObject CereseCreditP2;


    public void whenButtonClicked()
    {
        if (CereseCreditP1.activeInHierarchy)
        {
            CereseCreditP1.SetActive(false);

        }
        else
        {
            CereseCreditP1.SetActive(true);
        }


        if (CereseCreditP2.activeInHierarchy)
        {
            CereseCreditP2.SetActive(false);

        }
        else
        {
            CereseCreditP2.SetActive(true);
        }
    }
    }
