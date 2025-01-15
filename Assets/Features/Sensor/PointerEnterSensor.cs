using UnityEngine.EventSystems;
using R3;
using R3.Triggers;
using System;

public class PointerEnterSensor : Sensor
{
    public void Awake()
    {
        SensorTriggered = this.gameObject.AddComponent<ObservablePointerEnterTrigger>()
            .OnPointerEnterAsObservable()
            .Select(e => EventArgs.Empty);
    }
}