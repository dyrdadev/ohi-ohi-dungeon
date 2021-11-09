using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;

public class TriggerEnter2DSensor : Sensor
{
    /*public void Awake()
    {
        SensorTriggered = this.gameObject.AddComponent<ObservableTrigger2DTrigger>()
            .OnTriggerEnter2DAsObservable()
            .Select(e => EventArgs.Empty);
    }*/
}