using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI btext;

    public void Display(string txt) {
        btext.text = txt;
    }
}