using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event")]
public class GameEventSO : ScriptableObject
{
    // Use of HashSet prevents listeners from being added twice
    private HashSet<GameEventListener> listeners = new HashSet<GameEventListener>();

    // Invokes all subscribers to GameEvent Event
    public void Raise()
    {
        foreach (var globalEventListener in listeners)
        {
            globalEventListener.OnEventRaised();
        }
    }

    // Method for subscribing Listeners
    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    // Method for unsubscribing Listeners
    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
