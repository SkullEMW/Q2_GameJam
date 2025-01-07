using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int gameStartScene;
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }
}
