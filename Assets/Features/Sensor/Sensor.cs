using System;
using UnityEngine;
using UniRx;
using UnityEngine.EventSystems;

public abstract class Sensor : MonoBehaviour
{
    public IObservable<EventArgs> SensorTriggered;
}

public class PositionEventArgs : EventArgs
{
    public readonly Vector2 screenPosition;

    public PositionEventArgs(Vector2 pos) : base()
    {
        screenPosition = pos;
    }
}