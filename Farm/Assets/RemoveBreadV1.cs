using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBreadV1 : MonoBehaviour
{
    public event EventHandler removeBreadV1Clicked;

    public void clickedRemove() {
        removeBreadV1Clicked?.Invoke(this, EventArgs.Empty);
    }
}
