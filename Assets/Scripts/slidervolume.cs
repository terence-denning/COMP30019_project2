using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slidervolume : MonoBehaviour
{
    // Start is called before the first frame update
    private float volume;
    private Slider slider;
    void OnEnable()
    {
        GetComponent<Slider>().value = GlobalOptions.volume;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        GlobalOptions.volume = slider.value;
    }
}
