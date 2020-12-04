using System;
using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;

public class DoubleTapSensor : Sensor
{
    private void Awake()
    {
        var observable = this.gameObject.AddComponent<ObservablePointerDownTrigger>()
            .OnPointerDownAsObservable();
        
        SensorTriggered = observable
            .Buffer(observable.Throttle(TimeSpan.FromMilliseconds(150)))
            .Select(buffer => buffer.Count)
            .Where(count => count == 2)
            .Select(x => EventArgs.Empty);
    }
}