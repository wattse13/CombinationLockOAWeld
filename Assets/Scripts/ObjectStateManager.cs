using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStateManager : MonoBehaviour
{
    ObjectBaseState currentState;

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
        
    }

    public void SwitchState(ObjectBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
