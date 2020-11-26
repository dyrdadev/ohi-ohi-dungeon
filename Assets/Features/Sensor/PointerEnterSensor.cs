using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;
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