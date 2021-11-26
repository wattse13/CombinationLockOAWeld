using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

/// <summary>
///  Attatched to OnClickManager GameObject
///  Notifies subscribers when object has been clicked on
/// </summary> 

public class OnClick : MonoBehaviour
{
    public delegate void ClickEvent(GameObject myObject);
    public static event ClickEvent OnClicked;

    [SerializeField] private Camera _camera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // if (EventSystem.current.IsPointerOverGameObject()) // Allegedly prevents clicking through UI elements
                       // return;

            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject);
                    OnClicked?.Invoke(hit.collider.gameObject);
                }
            }
        }
    }
}
