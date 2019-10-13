using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    static bool GameIsPause = false;
    public GameObject pauseMenuUI;

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
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale =0.0f;
        GameIsPause = true;
    }
}
