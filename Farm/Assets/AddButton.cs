using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButton : MonoBehaviour
{
    //[SerializeField] private ProgressBar pfc; //In editor usage
    public event EventHandler addFlourClicked;
    public event EventHandler addBread1Clicked;
    public event EventHandler addBread2Clicked;

    public void clickedAddFlour() {
        ProgressBar pfc = this.transform.parent.gameObject.GetComponent<ProgressBarFlourCode>(); //In code usage
        if (pfc.number < pfc.capacity) {
            addFlourClicked?.Invoke(this, EventArgs.Empty);
        }
    }
    public void clickedAddBreadV1() {
        ProgressBar pfc = this.transform.parent.gameObject.GetComponent<ProgressBarBreadV1Code>(); //In code usage
        if (pfc.number < pfc.capacity) {
            addBread1Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
    public void clickedAddBreadV2() {
        ProgressBar pfc = this.transform.parent.gameObject.GetComponent<ProgressBarBreadV2Code>(); //In code usage
        if (pfc.number < pfc.capacity) {
            addBread2Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
