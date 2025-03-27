using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarBreadV2Code : ProgressBar
{
    public ProgressBarBreadV2Code() : base(10) {}

    [SerializeField] BreadFactoryV2 breadfactory2;

    private void Start() {
        breadfactory2.onCollectBread += BreadCollected;
    }

    public void BreadCollected(object sender, EventArguments e) {
        depoCount = 0;
        depotext.text = "" + depoCount;
    }
}
