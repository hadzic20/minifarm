using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarHayCode : ProgressBar
{
    public ProgressBarHayCode() : base(5) {}

    [SerializeField] private Buildings hayfactory;
    
    private void Start() {
        hayfactory.collectFromBuildings += HayCollected;
        line = 10000;
    }

    private void HayCollected(object sender, EventArguments e) {
        if (e.products == Factory.Hay) {
            depoCount = 0;
            depotext.text = depoCount.ToString();
            line++;
        }
    }
}
