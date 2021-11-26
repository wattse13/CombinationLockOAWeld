using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    // Game Event this Listener subscribes too
    [SerializeField]
    private GameEventSO gameEvent;

    // Unity Event triggered in response to GameEvent Event
    [SerializeField]
    private UnityEvent response;

    // Registers GameEvent to GameEventListener when this script is enabled
    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    // Deregisters GameEvent from GameEventListener when this scribe is disabled
    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    // Triggered when a GameEvent Event is registered
    public void OnEventRaised()
    {
        response.Invoke();
    }
}
