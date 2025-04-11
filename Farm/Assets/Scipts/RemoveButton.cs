using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveButton : MonoBehaviour
{
    [SerializeField] private ProgressBar pfc;
    public event EventHandler<EventArguments> removeSomething;

    public void clickedRemove() {
        removeSomething?.Invoke(this, new EventArguments(pfc.type));
    }
}
