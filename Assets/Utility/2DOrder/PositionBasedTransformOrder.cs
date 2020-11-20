using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBasedTransformOrder : MonoBehaviour
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Vector3 screenPos = _camera.WorldToScreenPoint(transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, (( screenPos.y - _camera.pixelHeight) / _camera.pixelHeight) * 5.0f);
    }
}
