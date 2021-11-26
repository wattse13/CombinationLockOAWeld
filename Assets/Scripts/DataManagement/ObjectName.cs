using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Attatched to Objects Which Need Names
///  Stores Reference to Object derived from Abstract Data Container Class
///  Sends String to Objects which Need Object Name
///  Keeps List of Possible Object Names
///  Dictionary populated by List (Would just use dictionary if dictionary was serilizable)
///  Recieves Notification from State Change and Updates thisObjectName based on key sent by delegate event
///  Subscriptions are not very generic
///  Should maybe split into two scripts? One for storing list and the other for exposing name to tooltip?
/// </summary>

public class ObjectName : MonoBehaviour
{
    [SerializeField] private DataStringSO thisObjectName;
    [SerializeField] private List<DataStringSO> possibleNames = new List<DataStringSO>();

    private Dictionary<string, DataStringSO> dictName = new Dictionary<string, DataStringSO>();

    // ToolTipComponent is subscribed to OnSentHovered
    // ClickMenuComponent is subscribed to OnSentClicked
    public delegate void SendStringData(string stringData);
    public static event SendStringData OnSentHovered;
    public static event SendStringData OnSentClicked;

    private void Awake()
    {
        // Doesn't scale well
        dictName.Add("stateOne", possibleNames[0]);
        dictName.Add("stateTwo", possibleNames[1]);
        dictName.Add("stateThree", possibleNames[2]);
        dictName.Add("stateFour", possibleNames[3]);

        // Debug.Log(thisObjectName.ObjectStringData);
    }

    private void OnEnable()
    {
        // Subscriptions are not super generic
        ToolTipComponent.OnHoverEntered += SendData;
        ClickMenuComponent.OnObjectClicked += SendClickData;
        ObjectUnsafeOffState.OnKeySent += RecieveData;
        ObjectUnsafeOnState.OnKeySent += RecieveData;
        ObjectSafeOffState.OnKeySent += RecieveData;
        ObjectSafeOnState.OnKeySent += RecieveData;
    }

    private void OnDisable()
    {
        ToolTipComponent.OnHoverEntered -= SendData;
        ClickMenuComponent.OnObjectClicked -= SendClickData;
        ObjectUnsafeOffState.OnKeySent -= RecieveData;
        ObjectUnsafeOnState.OnKeySent -= RecieveData;
        ObjectSafeOffState.OnKeySent -= RecieveData;
        ObjectSafeOnState.OnKeySent -= RecieveData;
    }

    // Necessary to send GameObject reference to ensure delegate event triggers only for object being hovered over
    private void SendData(GameObject myObject)
    {
        // Does this need another null check?
        if (myObject.TryGetComponent(out ObjectName name))
        {
            // OnSentHovered?.Invoke(name.thisObjectName.Data);
        }
    }

    // Necessary to send GameObject reference to ensure delegate event triggers only for object being hovered over
    // Copy of above function, but for click events
    private void SendClickData(GameObject myObject)
    {
        // Does this need another null check?
        if (myObject.TryGetComponent(out ObjectName name))
        {
            // OnSentClicked?.Invoke(name.thisObjectName.Data);
        }
    }

    private void RecieveData(string myKey)
    {
        thisObjectName = dictName[myKey];
    }
}
