using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsControllor : MonoBehaviour
{
    public Slider DifficultySlider;

    // Update is called once per frame
    public void Start()
    {
        DifficultySlider.value = GlobalOptions.difficulty;
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void DifficultySliderChanged()
    {
        GlobalOptions.difficulty = DifficultySlider.value;
    }
}
