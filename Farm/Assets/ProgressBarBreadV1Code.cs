using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarBreadV1Code : ProgressBar
{
    public ProgressBarBreadV1Code() : base(20) {}

    [SerializeField] BreadFactoryV1 breadfactory1;

    private void Start() {
        breadfactory1.onCollectBread += BreadCollected;
    }

    public void BreadCollected(object sender, EventArguments e) {
        depoCount = 0;
        depotext.text = "" + depoCount;
    }
}
