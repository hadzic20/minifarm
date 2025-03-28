using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarBreadV1Code : ProgressBar
{
    public ProgressBarBreadV1Code() : base(20) {}

    public event EventHandler<EventArguments> collectingBread1;
    [SerializeField] private RemoveBreadV1 rmv;
    [SerializeField] private BreadFactoryV1 breadfactory1;
    [SerializeField] private BreadFactoryV2 breadfactory2;
    [SerializeField] private FlourFactory flourfactory;
    [SerializeField] private HayFactory hayfactory;
    [SerializeField] private FlourCounter flourcount;
    [SerializeField] private GameObject remove;
    [SerializeField] private GameObject add;
    private bool buttonsOn = false;

    private void Start() {
        remove.SetActive(false);
        add.SetActive(false);
        breadfactory1.onCollectBread += BreadCollected;
        flourfactory.closeBreadButtons += CloseButtons;
        hayfactory.closeAllButtons += CloseButtons;
        breadfactory2.closeBread1andFlour += CloseButtons;
        flourcount.SentFlourForBread1 += AddBreadV1ToLine;
        rmv.removeBreadV1Clicked += RemoveFromLine;
    }

    private void BreadCollected(object sender, EventArguments e) {
        if (!buttonsOn) {
            remove.SetActive(true);
            add.SetActive(true);
            buttonsOn = true;
        }
        else {
            collectingBread1?.Invoke(this, new EventArguments(depoCount));
            number -= depoCount;
            depoCount = 0;
            depotext.text = depoCount.ToString();
        }
    }
    private void AddBreadV1ToLine(object sender, EventArgs e) {
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
