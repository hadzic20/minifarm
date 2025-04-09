using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreadCounter : MonoBehaviour
{
    private int breadCount = 0;
    [SerializeField] private TextMeshProUGUI btext;
    [SerializeField] private ProgressBarBreadV1Code breadfactory1;
    [SerializeField] private ProgressBarBreadV2Code breadfactory2;

    private void Start() {
        breadfactory1.collectingBread1 += BreadCollected;
        breadfactory2.collectingBread2 += BreadCollected;
    }

    private void BreadCollected(object sender, EventArguments e) {
        breadCount += e.value;
        btext.text = breadCount.ToString();
    }
}
