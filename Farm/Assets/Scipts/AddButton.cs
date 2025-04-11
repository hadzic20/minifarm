using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButton : MonoBehaviour
{
    [SerializeField] private ProgressBar pfc;
    public event EventHandler<EventArguments> RequestMaterials;

    public void clickedAdd() {
        if (pfc.number < pfc.capacity) {
            RequestMaterials?.Invoke(this, new EventArguments(pfc.type));
        }
    }
}
