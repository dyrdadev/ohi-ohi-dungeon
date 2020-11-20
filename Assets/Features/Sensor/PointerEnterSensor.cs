using UnityEngine.EventSystems;

public class PointerEnterSensor : Sensor, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData ped)
    {
        OnSensorTriggered();
    }
}