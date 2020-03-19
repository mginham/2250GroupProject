using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // Allows us to create this as an object with a right click
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--) {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener listener)
    {
        // Add listener
        listeners.Add(listener);
    }
    public void DeRegisterListener(SignalListener listener)
    {
        // Remove listener
        listeners.Remove(listener);
    }
}
