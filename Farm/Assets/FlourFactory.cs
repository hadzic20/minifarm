using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourFactory : MonoBehaviour
{
    [SerializeField] ProgressBarFlourCode pfr;
    public event EventHandler<EventArguments> onCollectFlour;

    void OnMouseDown() {
        onCollectFlour?.Invoke(this, new EventArguments(pfr.depoCount));
    }
}
