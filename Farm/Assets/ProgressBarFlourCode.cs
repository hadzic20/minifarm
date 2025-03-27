using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarFlourCode : ProgressBar
{
    public ProgressBarFlourCode() : base(10) {}

    [SerializeField] FlourFactory flourfactory;

    private void Start() {
        flourfactory.onCollectFlour += FlourCollected;
    }

    public void FlourCollected(object sender, EventArguments e) {
        depoCount = 0;
        depotext.text = "" + depoCount;
    }
}
