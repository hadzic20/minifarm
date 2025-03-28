using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HayCounter : MonoBehaviour
{
    private int hayCount = 0;
    [SerializeField] private TextMeshProUGUI htext;
    public event EventHandler SentHayForFlour;
    [SerializeField] private HayFactory hayfactory;
    [SerializeField] private AddFlourButton afb;

    private void Start() {
        hayfactory.onCollectHay += HayCollected;
        afb.addFlourClicked += HayUsed;
    }

    private void HayCollected(object sender, EventArguments e) {
        hayCount += e.value;
        htext.text = hayCount.ToString();
    }

    private void HayUsed(object sender, EventArgs e) {
        if (hayCount > 0) {
            hayCount--;
            htext.text = "" + hayCount;
            SentHayForFlour?.Invoke(this, EventArgs.Empty);
        }
    }
}
