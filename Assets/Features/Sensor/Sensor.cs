using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public abstract class Sensor : MonoBehaviour
{
    public event EventHandler SensorTriggered;
    
    protected virtual void OnSensorTriggered()
    {
        EventHandler handler = SensorTriggered;
        handler?.Invoke(this, EventArgs.Empty);
    }
}
