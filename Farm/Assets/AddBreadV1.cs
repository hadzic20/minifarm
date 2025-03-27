using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBreadV1 : MonoBehaviour
{
    public ProgressBarBreadV1Code pbc1;
    public event EventHandler addBread1Clicked;

    public void clickedAdd() {
        if (pbc1.number < 20) {
            addBread1Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
