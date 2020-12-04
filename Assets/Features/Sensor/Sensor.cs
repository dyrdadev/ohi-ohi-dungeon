using System;
using UnityEngine;
using UniRx;

public abstract class Sensor : MonoBehaviour
{
    public IObservable<EventArgs> SensorTriggered;
}