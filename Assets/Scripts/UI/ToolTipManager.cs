using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Attatched to ToolTipManager GameObject in UI Scene
// Changes ToolTip Text based on string recieved from delegate hover event
// Flips ToolTip Pivot based on mouse location
public class ToolTipManager : MonoBehaviour
{
    private TMP_Text toolTipContent;
    private RectTransform toolTipTransform;
    private string toolTipText;

    [SerializeField]
    private GameObject toolTipPanel;

    private void OnEnable()
    {
        // Subscribe to Hover event on Objects
    }

    private void OnDisable()
    {
        // DeSubscribe from Hover event on Objects
    }

    private void Start()
    {
        toolTipContent = GameObject.Find("ToolTipText").GetComponent<TMP_Text>();
        toolTipPanel.SetActive(false);
        // toolTipContent.text = "Hi There!";
    }
    
    // Called when delegate event is triggered
    private void SetAndShowText(string toolTipText)
    {
        toolTipPanel.SetActive(true);
        toolTipContent.text = toolTipText;
    }

    private void HideToolTip()
    {
        toolTipPanel.SetActive(false);
    }

    private void FlipPanelPivot()
    {
        // Get Mouse Location
        // If Mouse is on right side of screen, flip pivot point
        // If Mouse is on Left side of screen, flip pivot point
    }
}
