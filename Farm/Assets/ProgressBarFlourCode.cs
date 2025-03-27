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
    [SerializeField] FlourFactory flourfactory;
    [SerializeField] private GameObject remove;
    [SerializeField] private GameObject add;
    private bool buttonsOn = false;

    private void Start() {
        remove.SetActive(false);
        add.SetActive(false);
        flourfactory.onCollectFlour += FlourCollected;
    }

    public void FlourCollected(object sender, EventArguments e) {
        if (!buttonsOn) {
            remove.SetActive(true);
            add.SetActive(true);
            buttonsOn = true;
        }
        else {
            onCollectFlour?.Invoke(this, new EventArguments(depoCount));
            depoCount = 0;
            depotext.text = "" + depoCount;
        }
    }
}
