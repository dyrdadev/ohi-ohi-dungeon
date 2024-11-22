using System;
using UnityEngine.EventSystems;
using R3;
using R3.Triggers;

public class DoubleTapSensor : Sensor
{
    private void Awake()
    {
        var observable = this.gameObject.AddComponent<ObservablePointerDownTrigger>()
            .OnPointerDownAsObservable();
        
        SensorTriggered = observable
            .Chunk(observable.Debounce(TimeSpan.FromMilliseconds(150)))
            .Select(buffer => buffer.Length)
            .Where(count => count == 2)
            .Select(x => EventArgs.Empty);
    }
}