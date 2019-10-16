using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEditor;

public class ClickController : MonoBehaviour
{
    static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject player;
    public GameObject[] button;
    // Start is called before the first frame update


    // Update is called once per frame

    public void PauseButton()
    {
        if (GameIsPause)
        {
            Resume();
        }else{
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPause = false;
        foreach (var x in button)
        {
            x.SetActive(false);
            
        }
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale =0.0f;
        GameIsPause = true;
        if (player.GetComponent<ExpSystem>().modifiy == true)
        {
            foreach (var x in button)
            {
                x.SetActive(true);
            }
        }
    }

    public void Quit()
    {
        //Application.Quit();
        EditorApplication.Exit(0);
    }
}
