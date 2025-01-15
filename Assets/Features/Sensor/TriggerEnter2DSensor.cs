using UnityEngine;
using R3;
using System;
using R3.Triggers;

public class TriggerEnter2DSensor : Sensor
{
    public void Awake()
    {
        SensorTriggered = this.gameObject.AddComponent<ObservableTrigger2DTrigger>()
            .OnTriggerEnter2DAsObservable()
            .Select(e => EventArgs.Empty);
    }
}