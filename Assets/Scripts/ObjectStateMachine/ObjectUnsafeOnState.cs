using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUnsafeOnState : IObjectBaseState
{
    private Renderer myRenderer; // Meant for testing only

    private string stateKey = "stateFour";

    public delegate void SendStateKey(string stringData);
    public static event SendStateKey OnKeySent;

    public override void EnterState(ObjectStateManager interactable)
    {
        Debug.Log("Unsafe and On");
        StateChangeNotification();

        // Meant for testing only
        myRenderer = GameObject.Find("TestObject").GetComponent<Renderer>();
        myRenderer.material.color = Color.red;
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
