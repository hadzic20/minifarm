using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadFactoryV2 : MonoBehaviour
{
    [SerializeField] private ProgressBarBreadV2Code pbr2;
    public event EventHandler<EventArguments> onCollectBread;
    public event EventHandler closeBread1andFlour;

    private void OnMouseDown() {
        onCollectBread?.Invoke(this, new EventArguments(pbr2.depoCount));
        closeBread1andFlour?.Invoke(this, EventArgs.Empty);
    }
}
