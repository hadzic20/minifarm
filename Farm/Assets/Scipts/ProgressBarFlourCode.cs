using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBarFlourCode : ProgressBar
{
    public ProgressBarFlourCode() : base(10) {}

    [SerializeField] private AddButton adb;
    [SerializeField] private RemoveButton rmv;
    [SerializeField] private Counter haycounter;
    [SerializeField] private Buildings breadfactory1;
    [SerializeField] private Buildings breadfactory2;
    [SerializeField] private Buildings flourfactory;
    [SerializeField] private Buildings hayfactory;
    //[SerializeField] private HayCounter haycount;
    [SerializeField] private GameObject remove;
    [SerializeField] private GameObject add;
    private bool buttonsOn = false;
    

    private void Start() {
        remove.SetActive(false);
        add.SetActive(false);
        hayfactory.closeAllButtons += CloseButtons;
        breadfactory1.closeAllButtons += CloseButtons;
        breadfactory2.closeAllButtons += CloseButtons;
        flourfactory.collectFromBuildings += FlourCollected;
        //haycount.SentHayForFlour += AddFlourToLine;
        adb.RequestMaterials += RequestMaterial;
        haycounter.SentMaterials += AddFlourToLine;
        rmv.removeSomething += RemoveFromLine;
    }

    private void FlourCollected(object sender, EventArguments e) {
        if (e.products == Factory.Flour) {
            if (!buttonsOn) {
                remove.SetActive(true);
                add.SetActive(true);
                buttonsOn = true;
            }
            else {
                CollectThings(new EventArguments(depoCount, Factory.Flour));
                number -= depoCount;
                depoCount = 0;
                depotext.text = depoCount.ToString();
            }
        }
    }

    private void RequestMaterial(object sender, EventArguments e) {
        if (e.products == Factory.Flour) {
            UseThings(new EventArguments(1, Factory.Flour));
        }
    }

    private void AddFlourToLine(object sender, EventArguments e) {
        if (e.products == Factory.Flour) {
            line++;
            number++;
        }
    }

    private void RemoveFromLine(object sender, EventArguments e) {
        if (e.products == Factory.Flour && line > 0) {
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
