using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public float time;
    public int depoCount;
    public TextMeshProUGUI depotext;
    public TextMeshProUGUI bartext;
    public TextMeshProUGUI bartoptext;
    public int capacity;
    protected int line = 0;

    protected ProgressBar(int capac) {
        capacity = capac;
    }

    void Start()
    {
        time = 0;
        depoCount = 0;
        depotext.text = "" + depoCount;
    }

    void Update()
    {
        bartoptext.text = line + "/10";
        if (time <= slider.maxValue && depoCount < capacity) {
            time += Time.deltaTime;
            bartext.text = ((int) (slider.maxValue - time + 1)) + " sn";
            Progress(time);
        }
        else if (depoCount < capacity) {
            depoCount++;
            depotext.text = "" + depoCount;
            time = Time.deltaTime;
        }
        else {
            bartext.text = "FULL";
        }
    }

    void Progress(float progress) {
        slider.value = progress;
    }
}
