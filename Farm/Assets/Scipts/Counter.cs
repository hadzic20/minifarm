using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    private int number = 0;
    public event EventHandler<EventArguments> SentMaterials;
    [SerializeField] private Factory type;
    [SerializeField] private DisplayCounter display;
    [SerializeField] private ProgressBar hayfactory;
    [SerializeField] private FactoriesWithInput flourfactory;
    [SerializeField] private FactoriesWithInput breadfactory1;
    [SerializeField] private FactoriesWithInput breadfactory2;

    private void Start() {
        flourfactory.usingSomething += SomethingUsed;
        breadfactory1.usingSomething += SomethingUsed;
        breadfactory2.usingSomething += SomethingUsed;
        hayfactory.collectingSomething += SomethingCollected;
        flourfactory.collectingSomething += SomethingCollected;
        breadfactory1.collectingSomething += SomethingCollected;
        breadfactory2.collectingSomething += SomethingCollected;
    }

    private void SomethingCollected(object sender, EventArguments e) {
        Factory source = e.products;
        if (source == type || (type == Factory.BreadV1 && source == Factory.BreadV2)) {
            number += e.value;
            display.Display(number.ToString());
        }
    }

    private void SomethingUsed(object sender, EventArguments e) {
        if (e.products == type && number >= e.value) {
            SentMaterials?.Invoke(this, new EventArguments(e.goingTo));
            number -= e.value;
            display.Display(number.ToString());
        }
    }
}
