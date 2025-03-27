using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBreadV2 : MonoBehaviour
{
    public event EventHandler removeBreadV2Clicked;

    public void clickedRemove() {
        removeBreadV2Clicked?.Invoke(this, EventArgs.Empty);
    }
}
