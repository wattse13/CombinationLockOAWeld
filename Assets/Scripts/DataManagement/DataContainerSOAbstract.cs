using UnityEngine;

/// <summary>
/// Abstract Template for Data Container Objects
/// Holds Generic Data which is read-only
/// </summary>
/// <typeparam name="T"></typeparam>

public abstract class DataContainerSOAbstrac<T> : ScriptableObject
{
    public virtual T Data { get; }
}
