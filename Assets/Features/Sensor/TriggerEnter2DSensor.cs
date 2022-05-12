using System;
using UnityEngine;
using UniRx;
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