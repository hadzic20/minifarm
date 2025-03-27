using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFlourButton : MonoBehaviour
{
    public ProgressBarFlourCode pfc;
    public event EventHandler addFlourClicked;

    public void clickedAdd() {
        if (pfc.line < 10) {
            addFlourClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
