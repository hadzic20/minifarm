using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI bartext;
    [SerializeField] protected TextMeshProUGUI depotext;
    [SerializeField] protected TextMeshProUGUI bartoptext;

    public void UpdateSlider(int fulltime, float progress, bool full) {
        slider.value = progress;
        if (full)
            bartext.text = "FULL";
        else 
            bartext.text = ((int) (fulltime - progress + 1)) + " sn";
    }
    public void UpdateDepoText(string txt) {
        depotext.text = txt;
    }
    public void UpdateBarTopText(int number, int capacity) {
        bartoptext.text = number + "/" + capacity;
    }
}