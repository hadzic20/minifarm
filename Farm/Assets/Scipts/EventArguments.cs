using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArguments : EventArgs
{
    public int value;
    public Factory products;

    public EventArguments(Factory pr) {
        products = pr;
    }

    public EventArguments(int vl, Factory pr) {
        products = pr;
        value = vl;
    }
}
