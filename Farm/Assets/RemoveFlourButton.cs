using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveFlourButton : MonoBehaviour
{
    public event EventHandler removeFlourClicked;

    public void x() {
        Debug.Log("dfgerfd");
        removeFlourClicked?.Invoke(this, EventArgs.Empty);
    }
}
