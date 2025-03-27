using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadFactoryV2 : MonoBehaviour
{
    [SerializeField] ProgressBarBreadV2Code pbr2;
    public event EventHandler<EventArguments> onCollectBread;

    void OnMouseDown() {
        onCollectBread?.Invoke(this, new EventArguments(pbr2.depoCount));
    }
}
