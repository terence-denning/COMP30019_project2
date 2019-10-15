using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllor : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;

    }

    public void OptionScene()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void MainMenyScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    
}
