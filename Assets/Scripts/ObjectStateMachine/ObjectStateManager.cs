using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStateManager : MonoBehaviour
{
    IObjectBaseState currentState;

    // Should these be static? Currently creates four new states for every object. Probably not a big deal for projects of this scope
    // Also not sure if these should be public
    public ObjectUnsafeOffState unsafeOffState = new ObjectUnsafeOffState();
    public ObjectUnsafeOnState unsafeOnState = new ObjectUnsafeOnState();
    public ObjectSafeOffState safeOffState = new ObjectSafeOffState();
    public ObjectSafeOnState safeOnState = new ObjectSafeOnState();

    void Start()
    {
        // Starting state for the object state machine
        currentState = unsafeOffState;
        currentState.EnterState(this);
    }

    void Update()
    {
        // This is meant for testing purposes
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentState = unsafeOnState;
            currentState.EnterState(this);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentState = unsafeOffState;
            currentState.EnterState(this);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentState = safeOnState;
            currentState.EnterState(this);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentState = safeOffState;
            currentState.EnterState(this);
        }
    }

    public void SwitchState(IObjectBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
