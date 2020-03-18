using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu] // Allows us to create this as an object with a right click
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [NonSerialized]
    public float runtimeValue;

    public void OnAfterDeserialize()
    {
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize() { }
}
