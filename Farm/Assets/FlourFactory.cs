using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourFactory : MonoBehaviour
{
    [SerializeField] private ProgressBarFlourCode pfr;
    public event EventHandler<EventArguments> onCollectFlour;
    public event EventHandler closeBreadButtons;

    private void OnMouseDown() {
        onCollectFlour?.Invoke(this, new EventArguments(pfr.depoCount));
        closeBreadButtons?.Invoke(this, EventArgs.Empty);
    }
}
