using UnityEngine;
using System;

public class TriggerEnter2DSensor : MonoBehaviour // Change "MonoBehaviour" "to Sensor"
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        // OnSensorTriggered(EventArgs.Empty);
    }
}