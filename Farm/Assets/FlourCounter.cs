using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlourCounter : MonoBehaviour
{
    private int flourCount = 0;
    [SerializeField] private TextMeshProUGUI ftext;
    public event EventHandler SentFlourForBread1;
    public event EventHandler SentFlourForBread2;
    [SerializeField] private ProgressBarFlourCode flourfactory;
    [SerializeField] private AddButton abv;
    [SerializeField] private AddButton abv2;

    private void Start() {
        flourfactory.onCollectFlour += FlourCollected;
        abv.addBread1Clicked += FlourUsed2;
        abv2.addBread2Clicked += FlourUsed1;
    }

    private void FlourCollected(object sender, EventArguments e) {
        flourCount += e.value;
        ftext.text = flourCount.ToString();
    }

    private void FlourUsed2(object sender, EventArgs e) {
        if (flourCount > 1) {
            flourCount -= 2;
            ftext.text = flourCount.ToString();
            SentFlourForBread1?.Invoke(this, EventArgs.Empty);
        }
    }

    private void FlourUsed1(object sender, EventArgs e) {
        if (flourCount > 0) {
            flourCount--;
            ftext.text = flourCount.ToString();
            SentFlourForBread2?.Invoke(this, EventArgs.Empty);
        }
    }
}
