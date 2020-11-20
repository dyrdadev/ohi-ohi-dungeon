using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PointerEnterSensor : Sensor, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData ped)
    {
        OnSensorTriggered();
    }
}
