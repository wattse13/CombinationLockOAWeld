using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSafeOnState : IObjectBaseState
{
    private Renderer myRenderer; // Meant for testing only

    private string stateKey = "stateThree";

    public delegate void SendStateKey(string stringData);
    public static event SendStateKey OnKeySent;

    public override void EnterState(ObjectStateManager interactable)
    {
        Debug.Log("Safe and On");
        StateChangeNotification();

        // Meant for testing only
        myRenderer = GameObject.Find("TestObject").GetComponent<Renderer>();
        myRenderer.material.color = Color.yellow;
    }

    public override void UpdateLists(ObjectStateManager interactable)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(ObjectStateManager interactable)
    {
        throw new System.NotImplementedException();
    }

    public void StateChangeNotification()
    {
        OnKeySent?.Invoke(stateKey);
    }
}
