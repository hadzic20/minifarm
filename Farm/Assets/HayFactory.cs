using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayFactory : MonoBehaviour
{
    [SerializeField] ProgressBarHayCode pbr;
    public event EventHandler<EventArguments> onCollectHay;

    void OnMouseDown() {
        onCollectHay?.Invoke(this, new EventArguments(pbr.depoCount));
    }
}
