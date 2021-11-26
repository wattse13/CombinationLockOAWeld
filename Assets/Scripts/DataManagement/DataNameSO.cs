using UnityEngine;

/// <summary>
/// Not Currently in Use!!!
/// Scriptable Object which Inherits from DataContainerSOAbstract Class
/// Is Probably Some Over Engineering
/// Set up this way to prevent changs to data in data containers
/// Could probably be made a little more generic
/// </summary>

[CreateAssetMenu(menuName = "Object Data/String Data")]
public class DataNameSO : DataContainerSOAbstrac<string>
{
    [SerializeField] protected string _objectName; // Does making this protected rather than private do anything?

    public override string Data => _objectName;
}
