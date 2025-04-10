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
    [SerializeField] private RemoveButton rmv;
    [SerializeField] private Buildings breadfactory1;
    [SerializeField] private Buildings breadfactory2;
    [SerializeField] private Buildings flourfactory;
    [SerializeField] private Buildings hayfactory;
    [SerializeField] private HayCounter haycount;
    [SerializeField] private GameObject remove;
    [SerializeField] private GameObject add;
    private bool buttonsOn = false;
    

    private void Start() {
        remove.SetActive(false);
        add.SetActive(false);
        hayfactory.closeAllButtons += CloseButtons;
        breadfactory1.closeAllButtons += CloseButtons;
        breadfactory2.closeAllButtons += CloseButtons;
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
