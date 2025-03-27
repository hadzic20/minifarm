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
        hayCount--;
        htext.text = "" + hayCount;
    }
}
