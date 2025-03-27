using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HayCounter : MonoBehaviour
{
    private int hayCount = 0;
    public TextMeshProUGUI htext;
    [SerializeField] HayFactory hayfactory;

    private void Start() {
        hayfactory.onCollectHay += HayCollected;
    }

    public void HayCollected(object sender, EventArguments e) {
        hayCount += e.value;
        htext.text = "" + hayCount;
    }
}
