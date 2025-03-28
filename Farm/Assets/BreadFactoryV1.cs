using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadFactoryV1 : MonoBehaviour
{
    [SerializeField] private ProgressBarBreadV1Code pbr1;
    public event EventHandler<EventArguments> onCollectBread;
    public event EventHandler closeBread2andFlour;

    private void OnMouseDown() {
        onCollectBread?.Invoke(this, new EventArguments(pbr1.depoCount));
        closeBread2andFlour?.Invoke(this, EventArgs.Empty);
    }
}
