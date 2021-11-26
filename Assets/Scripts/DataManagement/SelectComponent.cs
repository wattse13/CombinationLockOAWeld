using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectComponent : MonoBehaviour
{
    [SerializeField] private GameEventSO OnObjectSelected;
    // [SerializeField] private ScriptableObject dataObject;

    private void Awake()
    {
        // Get ObjectName Component
    }

    private void OnMouseDown()
    {
        OnObjectSelected.Raise();
        // Debug.Log("hi from Select Component");
    }
}
