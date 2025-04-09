using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveButton : MonoBehaviour
{
    public event EventHandler removeFlourClicked;
    public event EventHandler removeBreadV1Clicked;
    public event EventHandler removeBreadV2Clicked;

    public void clickedRemoveFlour() {
        removeFlourClicked?.Invoke(this, EventArgs.Empty);
    }
    public void clickedRemoveBreadV1() {
        removeBreadV1Clicked?.Invoke(this, EventArgs.Empty);
    }
    public void clickedRemoveBreadV2() {
        removeBreadV2Clicked?.Invoke(this, EventArgs.Empty);
    }
}
