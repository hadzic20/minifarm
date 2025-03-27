using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadFactoryV1 : MonoBehaviour
{
    [SerializeField] ProgressBarBreadV1Code pbr1;
    public event EventHandler<EventArguments> onCollectBread;

    void OnMouseDown() {
        onCollectBread?.Invoke(this, new EventArguments(pbr1.depoCount));
    }
}
