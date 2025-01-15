using System;
using R3;
using UnityEngine;

[RequireComponent(typeof(Sensor))]
public class PlayerTap : DamageCause
{
    private Sensor _sensor;
    public DamageEffect damageEffect;
    
    [Header("VFX")]
    public GameObject damageVFX;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _sensor = GetComponent<Sensor>();
    }

    private void Start()
    {
        _sensor.SensorTriggered.Subscribe(DamageCauseSignalDetected).AddTo(this);
    }

    public void DamageCauseSignalDetected(EventArgs args)
    {
        damageEffect.Trigger(this);
        
        if (args is SensorEventArgs && ((SensorEventArgs)args).associatedPointerPayload.position != null)
        {
            Vector3 pos = _camera.ScreenToWorldPoint(((SensorEventArgs)args).associatedPointerPayload.position);
            Instantiate(damageVFX, new Vector3(pos.x, pos.y, damageVFX.transform.position.z), Quaternion.identity);
        }
    }
}
