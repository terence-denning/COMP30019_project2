using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllor : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");

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
