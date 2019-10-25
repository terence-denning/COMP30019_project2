using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgmvolume : MonoBehaviour
{
    private float volume;
    private Slider slider;
    // Start is called before the first frame update
    void OnEnable()
    {
        GetComponent<Slider>().value = GlobalOptions.bgmvolume;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        GlobalOptions.bgmvolume = slider.value;
    }
}
