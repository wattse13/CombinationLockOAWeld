using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attatched to Objects which need a Click Menu
/// Not sure if this apporach will work for multiple objects?
/// </summary>

public class ClickMenuComponent : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    // Serialized for testing purposes
    // Clicking on an object changes objectNameToSend variable for all objects with clickMenuComponent
    // Is probably okay, as the last clicked object should be object to send data...
    [SerializeField] private string objectNameToSend;

    public delegate void ClickMenuEvent(GameObject myObject);
    public static event ClickMenuEvent OnObjectClicked;

    private void OnEnable()
    {
        ObjectName.OnSentClicked += RecieveData;
    }

    private void OnDisable()
    {
        ObjectName.OnSentClicked -= RecieveData;
    }

    public void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                // Debug.Log(hit.collider.gameObject);
                OnObjectClicked?.Invoke(hit.collider.gameObject);
            }
        }
    }

    private void RecieveData(string myName)
    {
        objectNameToSend = myName;
    }

    private void SendData()
    {
        // Send Name Data to ClickMenuManager
    }
}
