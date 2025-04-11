using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoriesWithoutInput : ProgressBar
{
    [SerializeField] private Buildings factory;
    
    private void Start() {
        line = 10000;
        factory.collectFromBuildings += Collected;
    }

    private void Collected(object sender, EventArguments e) {
        CollectThings(new EventArguments(depoCount, type));
        line++;
    }
}
