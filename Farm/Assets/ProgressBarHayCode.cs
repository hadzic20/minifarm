using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarHayCode : ProgressBar
{
    public ProgressBarHayCode() : base(5) {}

    [SerializeField] HayFactory hayfactory;
    
    private void Start() {
        hayfactory.onCollectHay += HayCollected;
        line = 1000;
    }

    public void HayCollected(object sender, EventArguments e) {
        depoCount = 0;
        depotext.text = "" + depoCount;
    }
}
