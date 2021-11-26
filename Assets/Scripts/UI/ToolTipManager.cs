using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Attatched to ToolTipManager GameObject in UI Scene
/// Changes ToolTip Text based on string recieved from delegate hover event
/// Still needs method for keeping tooltip on screen for edge scenarios 
/// </summary>

public class ToolTipManager : MonoBehaviour
{
    [SerializeField] private RectTransform canvasRectTransform;
    [SerializeField] private GameObject toolTipPanel;

    private TMP_Text toolTipContent;
    private RectTransform toolTipTransform;

    private void Awake()
    {
        toolTipContent = GameObject.Find("ToolTipText").GetComponent<TMP_Text>();
        toolTipTransform = GameObject.Find("ToolTipBox").GetComponent<RectTransform>();
        toolTipPanel.SetActive(false);
    }

    private void OnEnable()
    {
        ObjectName.OnSentHovered += SetAndShowText;
        ToolTipComponent.OnHoverExited += HideToolTip;
    }

    private void OnDisable()
    {
        ObjectName.OnSentHovered -= SetAndShowText;
        ToolTipComponent.OnHoverExited -= HideToolTip;
    }

    private void Update()
    {
        SetToolTipPosition();
    }

    // Called when delegate event is triggered
    private void SetAndShowText(string stringData)
    {
        toolTipPanel.SetActive(true);
        toolTipContent.text = stringData;
    }

    // Called when delegate event is triggered
    private void HideToolTip()
    {
        toolTipPanel.SetActive(false);
        toolTipContent.text = null;
    }

    private void SetToolTipPosition()
    {
        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;
        toolTipTransform.anchoredPosition3D = anchoredPosition;

        // Still needs method of keeping tooltip on screen for edge cases
    }
}
