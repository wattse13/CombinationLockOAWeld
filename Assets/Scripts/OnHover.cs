using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  Attatched to OnHoverManager GameObject
///  Notifies subscribers when object has been hovered over
///  Not currently in Use!!!
/// </summary>
public class OnHover : MonoBehaviour
{
    public delegate void HoverEvent(GameObject interactableObject);
    public static event HoverEvent OnHovered;

    [SerializeField] private Camera _camera;

    public void OnMouseOver()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                // Debug.Log(hit.collider.gameObject);
                OnHovered?.Invoke(hit.collider.gameObject);
            }
        }
    }
}
