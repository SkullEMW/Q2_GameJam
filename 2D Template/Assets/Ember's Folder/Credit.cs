using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
   
    public void EmberCredits()
    {
        SceneManager.LoadScene("EmberCredit"); 
    }
    public void ChloeCredits()
    {
        SceneManager.LoadScene("ChloeCredit");
    }
    public void ScotCredits()
    {
        SceneManager.LoadScene("ScotCredit");
    }

    public void CereseCredits()
    {
        SceneManager.LoadScene("CereseCredit");
    }
    public void AngelCredits()
    {
        SceneManager.LoadScene("AngelCredit");
    }

    public void DominickCredits()
    {
        SceneManager.LoadScene("DominickCredit");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
