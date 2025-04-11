using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArguments : EventArgs
{
    public int value;
    public Factory products;
    public Factory goingTo;

    public EventArguments(Factory pr) {
        products = pr;
    }

    public EventArguments(int vl, Factory pr) {
        products = pr;
        value = vl;
    }

    public EventArguments(int vl, Factory pr, Factory gt) {
        products = pr;
        value = vl;
        goingTo = gt;
    }
}
