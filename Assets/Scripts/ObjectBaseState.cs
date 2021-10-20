using UnityEngine;

public abstract class ObjectBaseState
{
    public abstract void EnterState(ObjectStateManager interactable);
    public abstract void UpdateState(ObjectStateManager interactable); // Should this be broken up?
    // public abstract void UpdateImage(ObjectStateManager interactable);
    // public abstract void UpdateDescription(ObjectStateManager interactable);
    // public abstract void UpdateInteractivity(ObjectStateManager interactable);
    public abstract void UpdateLists(ObjectStateManager interactable);
}
