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
    public int number = 0;

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
        bartoptext.text = number + "/10";
        if (line > 0 && time <= slider.maxValue && depoCount < capacity) {
            time += Time.deltaTime;
            bartext.text = ((int) (slider.maxValue - time + 1)) + " sn";
            Progress(time);
        }
        else if (depoCount < capacity && line == 0) {
            time = Time.deltaTime;
            bartext.text = ((int) (slider.maxValue - time + 1)) + " sn";
            Progress(time);
        }
        else if (depoCount < capacity && line > 0) {
            line--;
            depoCount++;
            depotext.text = "" + depoCount;
            time = Time.deltaTime;
        }
        else if (depoCount == capacity) {
            bartext.text = "FULL";
        }
    }

    void Progress(float progress) {
        slider.value = progress;
    }
}
