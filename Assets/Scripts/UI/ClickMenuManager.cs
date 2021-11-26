using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Attached to ClickMenuManager in UI Scene
/// Should Display Data Sent by Object
/// </summary>

public class ClickMenuManager : MonoBehaviour
{
    [SerializeField] private Canvas clickMenuCanvas;
    [SerializeField] private TMP_Text objectName;

    private void Awake()
    {
        clickMenuCanvas = GameObject.Find("ClickMenuCanvas").GetComponent<Canvas>();
        objectName = GameObject.Find("ObjectNameText").GetComponent<TMP_Text>();

        clickMenuCanvas.enabled = true;
    }

    public void UpdateName(DataStringSO dataStringSO)
    {
        objectName.text = dataStringSO.ObjectStringData;
    }
}
