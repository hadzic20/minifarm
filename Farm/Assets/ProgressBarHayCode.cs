using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarHayCode : MonoBehaviour
{
    public Slider slider;
    public float time;

    void Start()
    {
        time = 0;
    }

    void Update()
    {
        if (time <= slider.maxValue) {
            time += Time.deltaTime;
            Progress(time);
        }
        else {
            time = Time.deltaTime;
        }
    }

    void Progress(float progress) {
        slider.value = progress;
    }
}
