using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter2DSensor : Sensor
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        OnSensorTriggered();
    }
}