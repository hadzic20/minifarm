using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreadCounter : MonoBehaviour
{
    private int breadCount = 0;
    [SerializeField] private TextMeshProUGUI btext;
    [SerializeField] private BreadFactoryV1 breadfactory1;
    [SerializeField] private BreadFactoryV2 breadfactory2;

    private void Start() {
        breadfactory1.onCollectBread += BreadCollected;
        breadfactory2.onCollectBread += BreadCollected;
    }

    private void BreadCollected(object sender, EventArguments e) {
        breadCount += e.value;
        btext.text = breadCount.ToString();
    }
}
