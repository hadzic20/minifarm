using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarBreadV2Code : ProgressBar
{
    public ProgressBarBreadV2Code() : base(10) {}

    public event EventHandler<EventArguments> collectingBread2;
    [SerializeField] RemoveBreadV2 rmv;
    [SerializeField] BreadFactoryV2 breadfactory2;
    [SerializeField] FlourCounter flourcount;
    [SerializeField] private GameObject remove;
    [SerializeField] private GameObject add;
    private bool buttonsOn = false;

    private void Start() {
        remove.SetActive(false);
        add.SetActive(false);
        breadfactory2.onCollectBread += BreadCollected;
        flourcount.SentFlourForBread2 += AddBreadV2ToLine;
        rmv.removeBreadV2Clicked += RemoveFromLine;
    }

    public void BreadCollected(object sender, EventArguments e) {
        if (!buttonsOn) {
            remove.SetActive(true);
            add.SetActive(true);
            buttonsOn = true;
        }
        else {
            collectingBread2?.Invoke(this, new EventArguments(depoCount));
            number -= depoCount;
            depoCount = 0;
            depotext.text = "" + depoCount;
        }
    }
    public void AddBreadV2ToLine(object sender, EventArgs e) {
        if (number < capacity) {
            line++;
            number++;
        }
    }

    public void RemoveFromLine(object sender, EventArgs e) {
        if (line > 0) {
            line--;
            number--;
        }
    }
}
