using System;
using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    public event EventHandler SensorTriggered;

    protected virtual void OnSensorTriggered()
    {
        var handler = SensorTriggered;
        handler?.Invoke(this, EventArgs.Empty);
    }
}