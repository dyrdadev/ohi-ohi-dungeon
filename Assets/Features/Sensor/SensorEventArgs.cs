using System;
using UnityEngine;
using R3;
using UnityEngine.EventSystems;

public class SensorEventArgs : EventArgs
{
    public readonly PointerEventData associatedPointerPayload;

    public SensorEventArgs(PointerEventData pointerPayload) : base()
    {
        associatedPointerPayload = pointerPayload;
    }
}