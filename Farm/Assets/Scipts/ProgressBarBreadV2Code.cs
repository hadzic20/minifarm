using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarBreadV2Code : ProgressBar
{
    public ProgressBarBreadV2Code() : base(10) {}

    [SerializeField] private AddButton adb;
    [SerializeField] private RemoveButton rmv;
    [SerializeField] private Counter flourcounter;
    [SerializeField] private Buildings breadfactory1;
    [SerializeField] private Buildings breadfactory2;
    [SerializeField] private Buildings flourfactory;
    [SerializeField] private Buildings hayfactory;
    //[SerializeField] private FlourCounter flourcount;
    [SerializeField] private GameObject remove;
    [SerializeField] private GameObject add;
    private bool buttonsOn = false;

    private void Start() {
        remove.SetActive(false);
        add.SetActive(false);
        breadfactory2.collectFromBuildings += BreadCollected;
        //flourcount.SentFlourForBread2 += AddBreadV2ToLine;
        breadfactory1.closeAllButtons += CloseButtons;
        flourfactory.closeAllButtons += CloseButtons;
        hayfactory.closeAllButtons += CloseButtons;
        adb.RequestMaterials += RequestMaterial;
        flourcounter.SentMaterials += AddBreadV2ToLine;
        rmv.removeSomething += RemoveFromLine;
    }

    private void BreadCollected(object sender, EventArguments e) {
        if (e.products == Factory.BreadV2) {
            if (!buttonsOn) {
                remove.SetActive(true);
                add.SetActive(true);
                buttonsOn = true;
            }
            else {
                CollectThings(new EventArguments(depoCount, Factory.BreadV2));
                number -= depoCount;
                depoCount = 0;
                depotext.text = depoCount.ToString();
            }
        }
    }

    private void RequestMaterial(object sender, EventArguments e) {
        if (e.products == Factory.BreadV2) {
            UseThings(new EventArguments(1, Factory.BreadV2));
        }
    }

    private void AddBreadV2ToLine(object sender, EventArguments e) {
        if (e.products == Factory.BreadV2) {
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
