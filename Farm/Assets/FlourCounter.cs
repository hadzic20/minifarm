using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlourCounter : MonoBehaviour
{
    private int flourCount = 0;
    public TextMeshProUGUI ftext;
    [SerializeField] FlourFactory flourfactory;

    private void Start() {
        flourfactory.onCollectFlour += FlourCollected;
    }

    public void FlourCollected(object sender, EventArguments e) {
        flourCount += e.value;
        ftext.text = "" + flourCount;
    }
}
