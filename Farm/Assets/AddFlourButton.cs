using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFlourButton : MonoBehaviour
{
    public event EventHandler addFlourClicked;

    void OnMouseDown() {
        Debug.Log("dfgerfd");
        addFlourClicked?.Invoke(this, EventArgs.Empty);
    }
}
