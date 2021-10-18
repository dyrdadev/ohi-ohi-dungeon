using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Sensor))]
public class DamageEffect : MonoBehaviour
{
    private Life _life;
    private Sensor damageCause;
    public float damage = 1.0f;
    [Space(5)]
    public GameObject damageVFX;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
        _life = GetComponentInParent<Life>();

        damageCause = GetComponent<Sensor>();
        damageCause.SensorTriggered.Subscribe(DamageCauseSignalDetected).AddTo(this);
    }

    public void DamageCauseSignalDetected(EventArgs args)
    {
        _life.DealDamage(damage);

        Vector3 pos = (args is PositionEventArgs) ? _cam.ScreenToWorldPoint(((PositionEventArgs)args).screenPosition) : transform.position;
        Instantiate(damageVFX, new Vector3(pos.x, pos.y, damageVFX.transform.position.z), Quaternion.identity);
    }
}