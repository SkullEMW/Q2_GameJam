using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public GameObject ChloeCreditP1;
    public GameObject ChloeCreditP2;
    

    public void whenButtonClicked()
    {
        if (ChloeCreditP1.activeInHierarchy)
        {
            ChloeCreditP1.SetActive(false);
    
        }
        else
        {
            ChloeCreditP1.SetActive(true);
        }


        if (ChloeCreditP2.activeInHierarchy)
        {
            ChloeCreditP2.SetActive(false);
            
        }
        else
        {
            ChloeCreditP2.SetActive(true);
        }



    }
        
}
