using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProductType
    {
        Hay,
        Flour,
        Bread1,
        Bread2
    }

public class Buildings : MonoBehaviour
{
    [SerializeField] private ProductType product;
    [SerializeField] private ProgressBar pb;
    public event EventHandler closeAllButtons;
    public event EventHandler<EventArguments> onCollectHay;
    public event EventHandler<EventArguments> onCollectFlour;
    public event EventHandler<EventArguments> onCollectBread1;
    public event EventHandler<EventArguments> onCollectBread2;
    private void OnMouseDown() {
        switch (product) {
            case ProductType.Hay:
                closeAllButtons?.Invoke(this, EventArgs.Empty);
                onCollectHay?.Invoke(this, new EventArguments(pb.depoCount));
                break;
            case ProductType.Flour:
                closeAllButtons?.Invoke(this, EventArgs.Empty);
                onCollectFlour?.Invoke(this, new EventArguments(pb.depoCount));
                break;
            case ProductType.Bread1:
                closeAllButtons?.Invoke(this, EventArgs.Empty);
                onCollectBread1?.Invoke(this, new EventArguments(pb.depoCount));
                break;
            case ProductType.Bread2:
                closeAllButtons?.Invoke(this, EventArgs.Empty);
                onCollectBread2?.Invoke(this, new EventArguments(pb.depoCount));
                break;
        }
    }
}
