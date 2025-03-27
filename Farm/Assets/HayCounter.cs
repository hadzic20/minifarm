using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HayCounter : MonoBehaviour
{
    private int hayCount = 0;
    public TextMeshProUGUI htext;
    public event EventHandler SentHayForFlour;
    [SerializeField] HayFactory hayfactory;
    [SerializeField] AddFlourButton afb;

    private void Start() {
        hayfactory.onCollectHay += HayCollected;
        afb.addFlourClicked += HayUsed;
    }

    public void HayCollected(object sender, EventArguments e) {
        hayCount += e.value;
        htext.text = "" + hayCount;
    }

    public void HayUsed(object sender, EventArgs e) {
        if (hayCount > 0) {
            hayCount--;
            htext.text = "" + hayCount;
            SentHayForFlour?.Invoke(this, EventArgs.Empty);
        }
    }
}
