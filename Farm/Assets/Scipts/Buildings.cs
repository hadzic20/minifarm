using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Factory
{
    Hay,
    Flour,
    BreadV1,
    BreadV2
}

public class Buildings : MonoBehaviour
{
    [SerializeField] private Factory product;
    [SerializeField] private ProgressBar pb;
    public event EventHandler<EventArguments> closeAllButtons;
    public event EventHandler<EventArguments> collectFromBuildings;
    
    private void OnMouseDown() {
        closeAllButtons?.Invoke(this, new EventArguments(pb.depoCount, product));
        collectFromBuildings?.Invoke(this, new EventArguments(pb.depoCount, product));
    }
}
