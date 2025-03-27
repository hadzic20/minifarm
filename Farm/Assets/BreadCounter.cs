using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreadCounter : MonoBehaviour
{
    private int breadCount = 0;
    public TextMeshProUGUI btext;
    [SerializeField] BreadFactoryV1 breadfactory1;
    [SerializeField] BreadFactoryV2 breadfactory2;

    private void Start() {
        breadfactory1.onCollectBread += BreadCollected;
        breadfactory2.onCollectBread += BreadCollected;
    }

    public void BreadCollected(object sender, EventArguments e) {
        breadCount += e.value;
        btext.text = "" + breadCount;
    }
}
