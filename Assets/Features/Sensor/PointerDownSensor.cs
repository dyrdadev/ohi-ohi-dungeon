using UnityEngine.EventSystems;

public class PointerDownSensor : Sensor, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData ped)
    {
        OnSensorTriggered();
    }
}