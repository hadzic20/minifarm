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
    [SerializeField] ProgressBarFlourCode flourfactory;
    [SerializeField] AddBreadV1 abv1;

    private void Start() {
        flourfactory.onCollectFlour += FlourCollected;
        abv1.addBread1Clicked += FlourUsed2;
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
}
