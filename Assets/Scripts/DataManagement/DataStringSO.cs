using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Simpler Object Data/String Data")]
public class DataStringSO : ScriptableObject
{
    [SerializeField]
    private string _objectStringData;

    public string ObjectStringData
    {
        get
        {
            return _objectStringData;
        }
    }
}
