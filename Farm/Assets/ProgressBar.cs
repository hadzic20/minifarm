using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float time;
    public int depoCount;
    [SerializeField] private TextMeshProUGUI bartext;
    [SerializeField] protected TextMeshProUGUI depotext;
    [SerializeField] protected TextMeshProUGUI bartoptext;
    protected int capacity;
    protected int line = 0;
    public int number = 0;

    protected ProgressBar(int capac) {
        capacity = capac;
    }

    private void Start()
    {
        time = 0;
        depoCount = 0;
        depotext.text = depoCount.ToString();
    }

    private void Update()
    {
        bartoptext.text = number + "/" + capacity;
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
            depotext.text = depoCount.ToString();
            time = Time.deltaTime;
        }
        else if (depoCount == capacity) {
            bartext.text = "FULL";
        }
    }

    private void Progress(float progress) {
        slider.value = progress;
    }
}
