using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    /// <summary>
    /// vào màn hình startmenu
    /// </summary>
   public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// chuyển màn level 1
    /// </summary>
    public void LoadMainGame()
    {
        SceneManager.LoadScene("Level1");
    }
    /// <summary>
    /// chuyển màn gameover
    /// </summary>
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    /// <summary>
    /// chuyển hướng thoát game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
