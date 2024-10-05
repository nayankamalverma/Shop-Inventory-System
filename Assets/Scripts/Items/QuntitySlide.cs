using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuntitySlide : MonoBehaviour
{
    [SerializeField] Slider quantity;
    [SerializeField] TextMeshProUGUI quantityText;

    private int quantityValue;

    private void Start()
    {
        quantityValue = 1;
    }

    private void Update()
    {
        quantityValue = (int)quantity.value;
    }
}
