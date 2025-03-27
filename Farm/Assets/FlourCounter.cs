using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlourCounter : MonoBehaviour
{
    private int flourCount = 0;
    public TextMeshProUGUI ftext;
    public event EventHandler SentFlourForBread1;
    public event EventHandler SentFlourForBread2;
    [SerializeField] ProgressBarFlourCode flourfactory;
    [SerializeField] AddBreadV1 abv1;
    [SerializeField] AddBreadV2 abv2;

    private void Start() {
        flourfactory.onCollectFlour += FlourCollected;
        abv1.addBread1Clicked += FlourUsed2;
        abv2.addBread2Clicked += FlourUsed1;
    }

    public void FlourCollected(object sender, EventArguments e) {
        flourCount += e.value;
        ftext.text = "" + flourCount;
    }

    public void FlourUsed2(object sender, EventArgs e) {
        if (flourCount > 1) {
            flourCount -= 2;
            ftext.text = "" + flourCount;
            SentFlourForBread1?.Invoke(this, EventArgs.Empty);
        }
    }

    public void FlourUsed1(object sender, EventArgs e) {
        if (flourCount > 0) {
            flourCount--;
            ftext.text = "" + flourCount;
            SentFlourForBread2?.Invoke(this, EventArgs.Empty);
        }
    }
}
