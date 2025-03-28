using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayFactory : MonoBehaviour
{
    [SerializeField] private ProgressBarHayCode pbr;
    public event EventHandler<EventArguments> onCollectHay;
    public event EventHandler closeAllButtons;

    private void OnMouseDown() {
        onCollectHay?.Invoke(this, new EventArguments(pbr.depoCount));
        closeAllButtons?.Invoke(this, EventArgs.Empty);
    }
}
