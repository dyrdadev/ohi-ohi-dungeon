using System;
using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    public event EventHandler SensorTrigger;

    protected virtual void OnSensorTrigger()
    {
        var handler = SensorTrigger;
        handler?.Invoke(this, EventArgs.Empty);
    }
}