using System;
 using UnityEngine;
 using UniRx;
 using UnityEngine.EventSystems;
 
 public abstract class Sensor : MonoBehaviour
 {
     public IObservable<EventArgs> SensorTriggered;
 }
 