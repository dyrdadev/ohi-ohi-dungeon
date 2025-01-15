using System;
using UnityEngine;
using R3;
using UnityEngine.EventSystems;
 
public abstract class Sensor : MonoBehaviour
{
    public Observable<EventArgs> SensorTriggered;
}
