using System;
using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;

public class PointerDownSensor : Sensor
{
    private void Awake()
    {
        SensorTriggered = this.gameObject.AddComponent<ObservablePointerDownTrigger>()
            .OnPointerDownAsObservable()
            .Select(e => EventArgs.Empty);
    }
}