using UnityEngine;

public class PositionBasedTransformOrder : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var screenPos = _camera.WorldToScreenPoint(transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y,
            (screenPos.y - _camera.pixelHeight) / _camera.pixelHeight * 5.0f);
    }
}