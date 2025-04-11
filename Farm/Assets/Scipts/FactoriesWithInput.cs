using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoriesWithInput : ProgressBar
{
    [SerializeField] private int requiresItem;
    [SerializeField] private Factory requiresThis;
    [SerializeField] private RemoveButton rmv;
    [SerializeField] private AddButton adb;
    [SerializeField] private Counter haycounter;
    [SerializeField] private Counter flourcounter;
    [SerializeField] private Buildings breadfactory1;
    [SerializeField] private Buildings breadfactory2;
    [SerializeField] private Buildings flourfactory;
    [SerializeField] private Buildings hayfactory;
    [SerializeField] private GameObject remove;
    [SerializeField] private GameObject add;
    private bool buttonsOn;

    private void Start() {
        buttonsOn = false;
        remove.SetActive(false);
        add.SetActive(false);
        breadfactory1.collectFromBuildings += Collect;
        breadfactory2.collectFromBuildings += Collect;
        flourfactory.collectFromBuildings += Collect;
        breadfactory1.collectFromBuildings += OpenButtons;
        breadfactory2.collectFromBuildings += OpenButtons;
        flourfactory.collectFromBuildings += OpenButtons;
        flourfactory.closeAllButtons += CloseButtons;
        hayfactory.closeAllButtons += CloseButtons;
        breadfactory1.closeAllButtons += CloseButtons;
        breadfactory2.closeAllButtons += CloseButtons;
        adb.RequestMaterials += RequestMaterial;
        haycounter.SentMaterials += AddToLine;
        flourcounter.SentMaterials += AddToLine;
        rmv.removeSomething += RemoveFromLine;
    }

    private void OpenButtons(object sender, EventArguments e) {
        if (e.products == type && !buttonsOn) {
            remove.SetActive(true);
            add.SetActive(true);
            buttonsOn = true;
        }
    }

    private void Collect(object sender, EventArguments e) {
        if (buttonsOn && depoCount > 0) {
            number -= depoCount;
            CollectThings(new EventArguments(depoCount, type));
        }
    }

    private void RequestMaterial(object sender, EventArguments e) {
        if (e.products == type) {
            UseThings(new EventArguments(requiresItem, requiresThis, type));
        }
    }

    private void AddToLine(object sender, EventArguments e) {
        if (e.products == type) {
            line++;
            number++;
        }
    }

    private void RemoveFromLine(object sender, EventArguments e) {
        if (e.products == type && line > 0) {
            line--;
            number--;
        }
    }

    private void CloseButtons(object sender, EventArguments e) {
        if (e.products != type) {
            remove.SetActive(false);
            add.SetActive(false);
            buttonsOn = false;
        }
    }
}
