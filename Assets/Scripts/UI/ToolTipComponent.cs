using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  Attatched to Objects Which Need ToolTips
///  Requires Collider and RigidBody I think?
///  Notifies subscribers when object has been hovered over
/// </summary>

public class ToolTipComponent : MonoBehaviour
{
    // ObjectName is subscribed to this event
    // Necessary to send GameObject reference to ensure delegate event triggers only for object being hovered over
    public delegate void HoverEnterEvent(GameObject myObject);
    public static event HoverEnterEvent OnHoverEntered;

    // ToolTipManager is subscribed to this event
    public delegate void HoverExitEvent();
    public static event HoverExitEvent OnHoverExited;

    [SerializeField] private Camera _camera;

    private void OnMouseOver()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                OnHoverEntered?.Invoke(hit.collider.gameObject);
            }
        }
    }

    private void OnMouseExit()
    {
        OnHoverExited?.Invoke();
    }
}
