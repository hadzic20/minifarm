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
    [SerializeField] RemoveFlourButton rmv;
    [SerializeField] FlourFactory flourfactory;
    [SerializeField] HayCounter haycount;
    [SerializeField] private GameObject remove;
    [SerializeField] private GameObject add;
    private bool buttonsOn = false;
    

    private void Start() {
        remove.SetActive(false);
        add.SetActive(false);
        flourfactory.onCollectFlour += FlourCollected;
        haycount.SentHayForFlour += AddFlourToLine;
        rmv.removeFlourClicked += RemoveFromLine;
    }

    public void FlourCollected(object sender, EventArguments e) {
        if (!buttonsOn) {
            remove.SetActive(true);
            add.SetActive(true);
            buttonsOn = true;
        }
        else {
            onCollectFlour?.Invoke(this, new EventArguments(depoCount));
            number -= depoCount;
            depoCount = 0;
            depotext.text = "" + depoCount;
        }
    }

    public void AddFlourToLine(object sender, EventArgs e) {
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
