using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUnsafeOffState : ObjectBaseState
{
    public override void EnterState(ObjectStateManager interactable)
    {
        Debug.Log("Hi from ObjectUnsafeOffState!");
    }

    public override void UpdateLists(ObjectStateManager interactable)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(ObjectStateManager interactable)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
