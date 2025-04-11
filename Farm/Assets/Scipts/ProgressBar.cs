using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ProgressBar : MonoBehaviour
{
    public event EventHandler<EventArguments> collectingSomething;
    [SerializeField] DisplayBar display;
    [SerializeField] int fullTime;
    public Factory type;
    private float time;
    public int depoCount;
    public int capacity;
    protected int line = 0;
    public int number = 0;

    private void Start()
    {
        time = 0;
        depoCount = 0;
        display.UpdateDepoText(depoCount.ToString());
    }

    protected void CollectThings(EventArguments e) {
        if (e.products == type) {
            collectingSomething?.Invoke(this, e);
            depoCount = 0;
            display.UpdateDepoText(depoCount.ToString());
        }
    }

    private void Update()
    {
        display.UpdateBarTopText(number, capacity);
        if (line > 0 && time <= fullTime && depoCount < capacity) {
            time += Time.deltaTime;
            display.UpdateSlider(fullTime, time, false);
        }
        else if (depoCount < capacity && line == 0) {
            time = Time.deltaTime;
            display.UpdateSlider(fullTime, time, false);
        }
        else if (depoCount < capacity && line > 0) {
            line--;
            depoCount++;
            display.UpdateDepoText(depoCount.ToString());
            time = Time.deltaTime;
        }
        else if (depoCount == capacity) {
            display.UpdateSlider(fullTime, time, true);
        }
    }
}
