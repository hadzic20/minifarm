using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArguments : EventArgs
{
    public int value;

    public EventArguments(int vl) {
        value = vl;
    }
}
