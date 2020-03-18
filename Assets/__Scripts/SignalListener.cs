using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent signalEvent;

    public void OnSignalRaised()
    {
        // Call the event
        signalEvent.Invoke();
    }

    private void OnEnable()
    {
        // Add listener
        signal.RegisterListener(this);
    }
    private void OnDisable()
    {
        // Remove listener
        signal.DeRegisterListener(this);
    }
}
