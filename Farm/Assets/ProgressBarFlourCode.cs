using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBarFlourCode : ProgressBar
{
    public ProgressBarFlourCode() : base(10) {}

    public event EventHandler<EventArguments> onCollectFlour;
    [SerializeField] private RemoveFlourButton rmv;
    [SerializeField] private BreadFactoryV1 breadfactory1;
    [SerializeField] private BreadFactoryV2 breadfactory2;
    [SerializeField] private FlourFactory flourfactory;
    [SerializeField] private HayFactory hayfactory;
    [SerializeField] private HayCounter haycount;
    [SerializeField] private GameObject remove;
    [SerializeField] private GameObject add;
    private bool buttonsOn = false;
    

    private void Start() {
        remove.SetActive(false);
        add.SetActive(false);
        hayfactory.closeAllButtons += CloseButtons;
        breadfactory1.closeBread2andFlour += CloseButtons;
        breadfactory2.closeBread1andFlour += CloseButtons;
        flourfactory.onCollectFlour += FlourCollected;
        haycount.SentHayForFlour += AddFlourToLine;
        rmv.removeFlourClicked += RemoveFromLine;
    }

    private void FlourCollected(object sender, EventArguments e) {
        if (!buttonsOn) {
            remove.SetActive(true);
            add.SetActive(true);
            buttonsOn = true;
        }
        else {
            onCollectFlour?.Invoke(this, new EventArguments(depoCount));
            number -= depoCount;
            depoCount = 0;
            depotext.text = depoCount.ToString();
        }
    }

    private void AddFlourToLine(object sender, EventArgs e) {
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
