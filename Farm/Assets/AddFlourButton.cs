using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFlourButton : MonoBehaviour
{
    [SerializeField] private ProgressBarFlourCode pfc;
    public event EventHandler addFlourClicked;

    public void clickedAdd() {
        if (pfc.number < 10) {
            addFlourClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
