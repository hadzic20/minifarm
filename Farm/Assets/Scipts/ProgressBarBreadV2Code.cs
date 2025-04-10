using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarBreadV2Code : ProgressBar
{
    public ProgressBarBreadV2Code() : base(10) {}

    public event EventHandler<EventArguments> collectingBread2;
    [SerializeField] private RemoveButton rmv;
    [SerializeField] private Buildings breadfactory1;
    [SerializeField] private Buildings breadfactory2;
    [SerializeField] private Buildings flourfactory;
    [SerializeField] private Buildings hayfactory;
    [SerializeField] private FlourCounter flourcount;
    [SerializeField] private GameObject remove;
    [SerializeField] private GameObject add;
    private bool buttonsOn = false;

    private void Start() {
        remove.SetActive(false);
        add.SetActive(false);
        breadfactory2.onCollectBread2 += BreadCollected;
        flourcount.SentFlourForBread2 += AddBreadV2ToLine;
        breadfactory1.closeAllButtons += CloseButtons;
        flourfactory.closeAllButtons += CloseButtons;
        hayfactory.closeAllButtons += CloseButtons;
        rmv.removeBreadV2Clicked += RemoveFromLine;
    }

    private void BreadCollected(object sender, EventArguments e) {
        if (!buttonsOn) {
            remove.SetActive(true);
            add.SetActive(true);
            buttonsOn = true;
        }
        else {
            collectingBread2?.Invoke(this, new EventArguments(depoCount));
            number -= depoCount;
            depoCount = 0;
            depotext.text = depoCount.ToString();
        }
    }
    private void AddBreadV2ToLine(object sender, EventArgs e) {
        if (number < capacity) {
            line++;
            number++;
        }
    }

    private void RemoveFromLine(object sender, EventArgs e) {
        if (line > 0) {
            line--;
            number--;
        }
    }

    private void CloseButtons(object sender, EventArgs e) {
        remove.SetActive(false);
        add.SetActive(false);
        buttonsOn = false;
    }
}
