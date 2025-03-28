using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBreadV2 : MonoBehaviour
{
    [SerializeField] private ProgressBarBreadV2Code pbc2;
    public event EventHandler addBread2Clicked;

    public void clickedAdd() {
        if (pbc2.number < 10) {
            addBread2Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
