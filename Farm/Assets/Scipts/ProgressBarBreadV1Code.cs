using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarBreadV1Code : ProgressBar
{
    public ProgressBarBreadV1Code() : base(20) {}

    //public event EventHandler<EventArguments> collectingBread1;
    [SerializeField] private RemoveButton rmv;
    [SerializeField] private AddButton adb;
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
        breadfactory1.collectFromBuildings += BreadCollected;
        flourfactory.closeAllButtons += CloseButtons;
        hayfactory.closeAllButtons += CloseButtons;
        breadfactory2.closeAllButtons += CloseButtons;
        adb.RequestMaterials += RequestMaterial;
        flourcounter.SentMaterials += AddBreadV1ToLine;
        //flourcount.SentFlourForBread1 += AddBreadV1ToLine;
        rmv.removeSomething += RemoveFromLine;
    }

    private void BreadCollected(object sender, EventArguments e) {
        if (e.products == Factory.BreadV1) {
            if (!buttonsOn) {
                remove.SetActive(true);
                add.SetActive(true);
                buttonsOn = true;
            }
            else {
                CollectThings(new EventArguments(depoCount, Factory.BreadV1));
                number -= depoCount;
                depoCount = 0;
                depotext.text = depoCount.ToString();
            }
        }
    }

    private void RequestMaterial(object sender, EventArguments e) {
        if (e.products == Factory.BreadV1) {
            UseThings(new EventArguments(2, Factory.BreadV1));
        }
    }

    private void AddBreadV1ToLine(object sender, EventArguments e) {
        if (e.products == Factory.BreadV1) {
            line++;
            number++;
        }
    }

    private void RemoveFromLine(object sender, EventArguments e) {
        if (e.products == Factory.BreadV1 && line > 0) {
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
