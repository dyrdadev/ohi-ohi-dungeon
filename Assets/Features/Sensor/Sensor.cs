using System;
using UnityEngine;
using UniRx;
using UnityEngine.EventSystems;

public abstract class Sensor : MonoBehaviour
{
    public IObservable<EventArgs> SensorTriggered;
}

public class SensorEventArgs : EventArgs
{
    public readonly PointerEventData associatedPointerPayload;

    public SensorEventArgs(PointerEventData pointerPayload) : base()
    {
        associatedPointerPayload = pointerPayload;
    }
}