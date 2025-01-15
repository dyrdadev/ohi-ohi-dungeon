using System;
using R3;
using R3.Triggers;

public class PointerDownSensor : Sensor
{
    private void Awake()
    {
        SensorTriggered = this.gameObject.AddComponent<ObservablePointerDownTrigger>()
            .OnPointerDownAsObservable()
            .Select(e => new SensorEventArgs(e) as EventArgs);
    }
}